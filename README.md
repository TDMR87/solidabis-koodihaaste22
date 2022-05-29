# Solidabis koodihaaste 2022 Frontend

Microsoftin Blazor frameworkilla toteutettu frontend lounaspaikkaäänestyssovellukseen. Sovellus hyödyntää mm. SignalR teknologiaa äänestystulosten reaaliaikaiseen esittämiseen.

Sovellusta kokeillaksesi sinun ei tarvitse asentaa tai ladata koneellesi mitään. Front- sekä backend pyörivät molemmat hallitsemallani web-palvelimella, ja pääset kokeilemaan sovellusta suoraan seuraavasta osoitteesta: 

http://koodihaaste22.diegoronkkomaki.com/

Sovelluksen sekä yksikkötestien lähdekoodit ovat tässä repositoriossa /src/ kansion sisällä: 

/src/frontend/Koodihaaste22Frontend/  
/src/frontend-test/Koodihaaste22Frontend.Tests/

Huomioita:

- Hakupalkin avulla voit etsiä eri paikkakuntien lounaspaikkoja.
- Voit antaa äänesi vain yhdelle lounaspaikalle (painamalla ravintolan sydän-ikonia). Voit myös poistaa jo antamasi äänen tai antaa äänesi jollekin toiselle lounaspaikalle, jolloin aiemmin antamasi ääni poistuu automaattisesti. Lounaspaikan saama äänimäärä näkyy aina reaaliaikaisena sivustolla, heti kun annat tai poistat äänesi.
- Lounaspaikkojen järjestys muuttuu saatujen äänien mukaan. Eniten ääniä saanut lounaspaikka on ylimpänä.
- Sovellus ei käytä tällä hetkellä mitään autentikaatiomekanismia. Keksit ovat selainkohtaisia, jolloin yksi henkilö voi emuloida useampaa käyttäjää avaamalla sovelluksen eri selaimissa (siis working as intended, for now).

![Alt text](/src/frontend/Koodihaaste22Frontend/Koodihaaste22Frontend/wwwroot/img/screenshot1.png?raw=true "Kuvakaappaus")