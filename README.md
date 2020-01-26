# Currency Quotation

Bienvenido al cotizador de Pesos Argentinos:

Este proyecto implementa una Web Api RESTful que retorna las cotizaciones de monedas en base al Peso Argentino usando la api [cambio.today](http://cambio.today/)

Puede probar la aplicación web [aquí](https://currencyquotation.azurewebsites.net/quotation)

## Tecnologías usadas
- **Backend:** C#, ASP.NET MVC Core
- **Frontend:** Angular

## Ejemplo de uso
### Petición
- **Verbo http:** GET
- **Url:** https://[[hostname]]/Quotation/USD

### Respuesta
<img alt='Ejemplo de llamada a la api' src="https://currencyquotation.azurewebsites.net/assets/api-request-example.PNG" />

- **updated:** Fecha de la última actualización de la cotización
- **source:** Moneda base de la cotización
- **target:** Moneda a cotizar
- **quantity:** Unidad de cotización
- **amount:** Cotización

## Agregar monedas a cotizar en la aplicación web
Para agregar monedas en la aplicación web, dirigirse al archivo **config.json** ubicado en la carpeta **src\assets** de la aplicación Angular

Para ello necesitara saber el código de la moneda [ISO 4217](https://es.wikipedia.org/wiki/ISO_4217#C%C3%B3digos_de_divisa_ISO_4217[nota_1]%E2%80%8B)
<img alt='Ejemplo de llamada a la api' src="https://currencyquotation.azurewebsites.net/assets/currencies-file.PNG" />
