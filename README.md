# Solidabis koodihaaste 2022 Frontend

Microsoftin Blazor frameworkilla toteutettu frontend lounaspaikkaäänestyssovellukseen. Sovellus hyödyntää mm. SignalR teknologiaa äänestystulosten reaaliaikaiseen esittämiseen.

Sovellusta kokeillaksesi sinun ei tarvitse asentaa tai ladata koneellesi mitään. Front- sekä backend pyörivät molemmat hallitsemallani web-palvelimella, ja pääset kokoeilemaan sovellusta suoraan seuraavasta osoitteesta: http://koodihaaste22.diegoronkkomaki.com/. Oikeassa elämässä yritys voisi laittaa sovelluksen pyörimään esimerkiksi firman omaan sisäverkkoon.

Huomioita:

- Hakupalkin avulla voit etsiä eri paikkakuntien lounaspaikkoja.
- Voit antaa äänesi vain yhdelle lounaspaikalle (painamalla ravintolan sydän-ikonia). Voit myös poistaa jo antamasi äänen tai antaa äänesi jollekin toiselle lounaspaikalle, jolloin aiemmin antamasi ääni poistuu automaattisesti. Lounaspaikan saama äänimäärä näkyy aina reaaliaikaisena sivustolla, heti kun annat tai poistat äänesi.
- Lounaspaikkojen järjestys muuttuu saatujen äänien mukaan. Eniten ääniä saanut lounaspaikka on ylimpänä.
- Sovellus ei käytä tällä hetkellä mitään autentikaatiomekanismia. Keksit ovat selainkohtaisia, jolloin yksi henkilö voi emuloida useampaa käyttäjää avaamalla sovelluksen eri selaimissa (siis working as intended, for now).

![Alt text](/src/frontend/Koodihaaste22Frontend/Koodihaaste22Frontend/wwwroot/img/screenshot1.png?raw=true "Optional Title")

***

Tehtävänäsi on toteuttaa lounaspaikkaäänestyssovelluksen frontend valmista APIa vasten (työkalut saat valita itse).
Arvosteluperusteet tärkeysjärjestyksessä:

 1. Ratkaisun oikeellisuus
    1. ravintoloiden haku paikkakuntakohtaisesti
    2. äänen antaminen, muuttaminen ja poistaminen
    3. äänestystulosten esittäminen reaaliajassa
 2. Testit
 3. Ratkaisun selkeys ja yksinkertaisuus
 4. Käyttöliittymäratkaisut

Tässä repositoryssä on valmis Spring Bootilla toteutettu backend, joka toteuttaa lounaspaikkojen
haku- ja äänestyslogiikan käyttäen Lounaat.info -palvelua.

Backendin ajamiseen tarvitset JDK:n (versio>=11) ja/tai Dockerin asennettuna työasemallesi.

Backendin käynnistys:

    ./gradlew bootRun

tai Dockerilla:

    docker run -p 8080:8080 solidabis/koodihaaste22:latest

Tutustu API-dokumentaatioon http://localhost:8080/swagger-ui.html

Päivä/selainkohtainen äänioikeus on toteutettu HTTP-only -cookiella.

# Palautus

_Forkkaa tästä repositorystä oma julkinen ratkaisureposi_ ja lähetä linkki 31.5.2022 mennessä sähköpostilla osoitteeseen
koodihaaste@solidabis.com. Muokkaa README.md -tiedostoa siten, että siitä ilmenee vastauksen
tarkastelua helpottavat tiedot, kuten käyttämäsi teknologiat ja muutaman lauseen kuvaus tekemistäsi
ratkaisuista. Voit myös julkaista ratkaisusi esim. Herokuun, muista liittää linkki ja mahdolliset salasanat sähköpostiin!

Backendin muuttaminen esim. autentikoinnin toteuttamiseksi on sallittua.

Kerro samalla haluatko osallistua vain kilpailuun ja arvontaan, vai haluatko Solidabiksen
ottavan yhteyttä myös työtarjouksiin liittyen. Se ei tarkoita, että sinulle lähetettäisiin roskapostia, vaan nimensä
mukaisesti esimerkiksi kutsu työhaastatteluun. Voit halutessasi
osallistua koodihasteeseen myös ilman, että haluat ottaa palkintoa
vastaan tai osallistua arvontaan.
