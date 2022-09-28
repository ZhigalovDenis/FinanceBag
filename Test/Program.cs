using Test;


GetPriceApiMoexFromString getPriceApiMoexFromString = new GetPriceApiMoexFromString();
await getPriceApiMoexFromString.GetPrice();


GetPriceApiMoexFromXml getPriceApiMoexFromXml = new GetPriceApiMoexFromXml();
await getPriceApiMoexFromXml.GetPrice();


GetPriceApiMoexFromXmlProd getPriceApiMoexFromStringProd = new GetPriceApiMoexFromXmlProd();
await getPriceApiMoexFromStringProd.GetPrice();

