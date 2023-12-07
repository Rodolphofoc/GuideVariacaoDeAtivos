using Domain.Domain;

namespace Tests
{
    public class MetaEntityBuilder
    {

        private MetaEntity _metaEntity = new MetaEntity { };


        public MetaEntity GetMeta()
        {
            _metaEntity.Id = 1;
            _metaEntity.Currency = "BRL";
            _metaEntity.Symbol = "PETR4.SA";
            _metaEntity.ExchangeName = "SAO";
            _metaEntity.InstrumentType = "EQUITY";
            _metaEntity.FirstTradeDate = DateTime.Now;
            _metaEntity.RegularMarketTime = DateTime.Now;
            _metaEntity.Gmtoffset = -10800;
            _metaEntity.Timezone = "BRT";
            _metaEntity.ExchangeTimezoneName = "America/Sao_Paulo";
            _metaEntity.RegularMarketPrice = (float)33.5;
            _metaEntity.ChartPreviousClose = (float)35.51;
            _metaEntity.PriceHint = 2;
            
            _metaEntity.IntegrationId = Guid.Parse("2c35b444-6efe-42ed-b701-f461a000eb06");
            _metaEntity.Quote = new QuoteEntity()
            {
                MetaId = 1,
                Id = 1,
            };
            _metaEntity.Quote.Open = new List<OpenEntity>()
            {
                new OpenEntity()
                {
                    Id = 1,
                    Value = (float) 30.4,
                    Date = DateTime.Now.AddDays(-3),
                },
                                new OpenEntity()
                {
                    Id = 1,
                    Value = (float) 30.4,
                    Date = DateTime.Now.AddDays(-2),
                },
                new OpenEntity()
                {
                    Id = 1,
                    Value = (float) 30.4,
                    Date = DateTime.Now.AddDays(-1),
                }
            };


            return _metaEntity;

        }
    }
}
