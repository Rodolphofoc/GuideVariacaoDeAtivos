using Applications.Finance.Models;
using Applications.Interfaces.Repository;
using Applications.Interfaces.Service;
using Domain;
using Domain.Domain;
using MediatR;
using System.Net;

namespace Applications.Finance.Commands.Handlers
{
    public class FinanceUpdateDataBaseCommandHandler : IRequestHandler<FinanceUpdateDataBaseCommand, Response>
    {
        private readonly IResponse _response;
        private readonly IFinanceService _financeService;
        private readonly IMetaRepository _metaRepository;
        private readonly IUnitOfWork _unitOfWork;


        public FinanceUpdateDataBaseCommandHandler(IResponse response, IFinanceService financeService, IMetaRepository metaRepository, IUnitOfWork unitOfWork)
        {
            _response = response;
            _financeService = financeService;
            _metaRepository = metaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(FinanceUpdateDataBaseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var responseFinance = await _financeService.GetDataFinance();

                if (responseFinance == null)
                    return await _response.CreateErrorResponseAsync(null, HttpStatusCode.BadRequest);

                await ProcessData(responseFinance);
                await _unitOfWork.CompleteAsync();
                return await _response.CreateSuccessResponseAsync(null, string.Empty);

            }
            catch (Exception)
            {
                return await _response.CreateErrorResponseAsync(null, HttpStatusCode.InternalServerError);
            }
        }


        private async Task ProcessData(ResponseFinance? response)
        {
                foreach (var data in response.chart.result)
                {
                    var entity = await CreateEntityMeta(data.meta);
                    entity = await AddQuote(entity, data.indicators.quote.ToList(), data.timestamp.ToList());
                }
        }


        private async Task<MetaEntity> CreateEntityMeta(Meta model)
        {
            var metaEntity = new MetaEntity()
            {
                ChartPreviousClose = model.chartPreviousClose,
                Currency = model.currency,
                DataGranularity = model.dataGranularity,
                ExchangeName = model.exchangeName,
                Symbol = model.symbol,
                InstrumentType = model.instrumentType,
                FirstTradeDate = MapToDateTime(model.firstTradeDate, model.gmtoffset),
                RegularMarketTime = MapToDateTime(model.regularMarketTime, model.gmtoffset),
                Gmtoffset = model.gmtoffset,
                Scale = model.scale,
                PriceHint = model.priceHint,
                Timezone = model.timezone,
                Range = model.range,
                ExchangeTimezoneName = model.exchangeTimezoneName,
                RegularMarketPrice = model.regularMarketPrice,
                PreviousClose = model.previousClose


            };

            metaEntity = await _metaRepository.AddAsync(metaEntity);

            metaEntity = await AddCurrentTradingPeriod(metaEntity, model);
            metaEntity = await AddTradingPeriods(metaEntity, model);
            metaEntity = await AddValidRanges(metaEntity, model);



            return metaEntity;
        }

        private DateTime MapToDateTime(int time, int gmtOffsetSeconds)
        {
            DateTimeOffset resultDateTime = DateTimeOffset.FromUnixTimeSeconds(time);
            resultDateTime = resultDateTime.ToOffset(new TimeSpan(0, 0, gmtOffsetSeconds));
            return resultDateTime.Date;
        }
        private DateTime MapTimeStamp(int time)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(time);
            DateTime dateTime = dateTimeOffset.UtcDateTime;

            return dateTime.ToLocalTime();
        }
        private async Task<MetaEntity> AddCurrentTradingPeriod(MetaEntity metaEntity, Meta model)
        {
            var pre = new CurrentTradingPeriodEntity()
            {
                Type = "pre",
                Start = MapToDateTime(model.currentTradingPeriod.pre.start, model.currentTradingPeriod.pre.gmtoffset),
                End = MapToDateTime(model.currentTradingPeriod.pre.end, model.currentTradingPeriod.pre.gmtoffset),
                Gmtoffset = model.currentTradingPeriod.pre.gmtoffset,
                Timezone = model.timezone

            };


            var regular = new CurrentTradingPeriodEntity()
            {
                Type = "regular",
                Start = MapToDateTime(model.currentTradingPeriod.regular.start, model.currentTradingPeriod.regular.gmtoffset),
                End = MapToDateTime(model.currentTradingPeriod.regular.end, model.currentTradingPeriod.regular.gmtoffset),
                Gmtoffset = model.currentTradingPeriod.regular.gmtoffset,
                Timezone = model.timezone
            };

            var post = new CurrentTradingPeriodEntity()
            {
                Type = "post",
                Start = MapToDateTime(model.currentTradingPeriod.post.start, model.currentTradingPeriod.post.gmtoffset),
                End = MapToDateTime(model.currentTradingPeriod.post.end, model.currentTradingPeriod.post.gmtoffset),
                Gmtoffset = model.currentTradingPeriod.post.gmtoffset,
                Timezone = model.timezone

            };

            metaEntity.CurrentTradingPeriod.Add(pre);
            metaEntity.CurrentTradingPeriod.Add(regular);
            metaEntity.CurrentTradingPeriod.Add(post);

            return metaEntity;
        }
        private async Task<MetaEntity> AddTradingPeriods(MetaEntity metaEntity, Meta model)
        {
            if (model.tradingPeriods != null && model.tradingPeriods.Any())
            {
                foreach (var period in model.tradingPeriods.FirstOrDefault())
                {

                    metaEntity.TradingPeriods.Add(new TradingPeriodEntity()
                    {
                        Timezone = period.timezone,
                        End = MapToDateTime(period.end, period.gmtoffset),
                        Start = MapToDateTime(period.start, period.gmtoffset),
                        Gmtoffset = period.gmtoffset
                    });
                }
            }

            return metaEntity;

        }
        private async Task<MetaEntity> AddValidRanges(MetaEntity metaEntity, Meta model)
        {
            if (model.validRanges.Any())
            {
                foreach (var ranges in model.validRanges)
                {
                    metaEntity.ValidRanges.Add(new ValidRangesEntity()
                    {
                        Value = ranges
                    });
                }
            }

            return metaEntity;
        }
        private async Task<MetaEntity> AddQuote(MetaEntity metaEntity, List<Quote> model, List<int> timestamp)
        {
            if (model.Any() && timestamp.Any())
            {

                foreach (var list in model)
                {

                    var resultHigh = list.high.Zip(timestamp, (x, y) => new { value = x, date = y });

                    foreach (var item in resultHigh)
                    {
                        metaEntity.Quote.High.Add(new HighEntity()
                        {
                            Value = item.value is null ? 0 : item.value,
                            Date = MapTimeStamp(item.date) ,
                            TimeStamp = item.date
                        });
                    }

                    var resultlow = list.low.Zip(timestamp, (x, y) => new { value = x, date = y });

                    foreach (var item in resultlow)
                    {
                        metaEntity.Quote.Low.Add(new LowEntity()
                        {
                            Value = item.value is null ? 0 : item.value,
                            Date = MapTimeStamp(item.date),
                            TimeStamp = item.date

                        });
                    }

                    var resultopen = list.open.Zip(timestamp, (x, y) => new { value = x, date = y });

                    foreach (var item in resultopen)
                    {
                        metaEntity.Quote.Open.Add(new OpenEntity()
                        {
                            Value = item.value is null ? 0 : item.value,
                            Date = MapTimeStamp(item.date),
                            TimeStamp = item.date

                        });
                    }

                    var resultvolume = list.volume.Zip(timestamp, (x, y) => new { value = x, date = y });

                    foreach (var item in resultvolume)
                    {
                        metaEntity.Quote.Volume.Add(new VolumeEntity()
                        {
                            Value = item.value is null ? 0 : item.value,
                            Date = MapTimeStamp(item.date),
                            TimeStamp = item.date

                        });
                    }
                }

            }
            return metaEntity;
        }

    }
}
