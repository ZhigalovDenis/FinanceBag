using Test;


GetPriceApiMoexFromString getPriceApiMoexFromString = new GetPriceApiMoexFromString();
await getPriceApiMoexFromString.GetPrice();


GetPriceApiMoexFromXml getPriceApiMoexFromXml = new GetPriceApiMoexFromXml();
await getPriceApiMoexFromXml.GetPrice();


GetPriceApiMoexFromXmlProd getPriceApiMoexFromXmlProd = new GetPriceApiMoexFromXmlProd();
await getPriceApiMoexFromXmlProd.GetPrice();

