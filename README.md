[![Open in Codespaces](https://classroom.github.com/assets/launch-codespace-7f7980b617ed060a017424585567c406b6ee15c891e84e1186181d67ecf80aa0.svg)](https://classroom.github.com/open-in-codespaces?assignment_repo_id=14236161)
**(ERASMUS students please see the english version (README_ENG.md) of this document)**

# Inicijalne upute za prijavu 1. projekta iz kolegija Testiranje i kvaliteta programskih proizvoda

Poštovane kolegice i kolege, 

čestitamo vam jer ste uspješno prijavili svoj projektni tim na kolegiju Testiranje i kvaliteta programskih proizvoda, te je za vas automatski kreiran repozitorij koji ćete koristiti za verzioniranje vašega koda, testova, ali i za pisanje dokumentacije.

Ovaj dokument (README.md) predstavlja **osobnu iskaznicu vašeg projekta**. Vaš prvi zadatak je **prijaviti vlastiti projektni prijedlog** na način da ćete prijavu vašeg projekta, sukladno uputama danim u ovom tekstu, napisati upravo u ovaj dokument, umjesto ovoga teksta.

Za upute o sintaksi koju možete koristiti u ovom dokumentu i kod pisanje vaše projektne dokumentacije pogledajte [ovaj link](https://guides.github.com/features/mastering-markdown/).
Sav programski kod i testove je potrebno verzionirati u glavnoj **master** grani i **obvezno** smjestiti u mapu Software. Sve artefakte (npr. slike) koje ćete koristiti u vašoj dokumentaciju obvezno verzionirati u posebnoj grani koja je već kreirana i koja se naziva **master-docs** i smjestiti u mapu Documentation.

Povratnu informaciju na samu prijavu tima i projekta, kao i na završnu predaju ćete od nastavnika dobiti kroz sekciju Discussions (također dostupnu na GitHubu vašeg projekta). A sada, vrijeme je da prijavite vaš projekt. Za prijavu vašeg projektnog prijedloga molimo vas koristite **predložak** koji je naveden u nastavku, a započnite tako da kliknete na *olovku* u desnom gornjem kutu ovoga dokumenta :) 

# Event Manager

## Model rada na projektu
(1) Nastavak rada na projektu iz kolegija "Razvoj programskih proizvoda".

## Opis projekta
Event Manager je softversko rješenje dizajnirano da olakša organizaciju i upravljanje različitim vrstama događaja kao što su koncerti, zabave, radionice ili bilo kakvi javni ili privatni događaji. Ova aplikacija omogućava korisnicima da stvore, urede, pregledaju i obrišu događaje, upravljaju kartama, ostavljaju recenzije te da prate informacije o gostima, datumima, lokacijama i drugim relevantnim detaljima. Projekt je incijalno započet na kolegiju "Razvoj programskih proizvoda". Inicijalne tehnologije korištene za prethodnu izradu projekta su bile: Github, Visual Studio (WinForms tehnologija), .NET Framework, Microsoft SSMS, Visual Paradigm.

## Projektni tim

Ime i prezime | E-mail adresa (FOI) | JMBAG | Github korisničko ime
------------  | ------------------- | ----- | ---------------------
Mateo Pikl | mpikl2020@student.foi.hr | 0016151626 | mpikl
Toni Leo Modrić Dragičević | tmodricdr20@student.foi.hr | 0016150195 | tmodricdr20
Borna Kadežabek | bkadezabe20@foi.hr | 0016148410 | bkadezabe20

## Specifikacija projekta
Oznaka | Naziv | Kratki opis | Odgovorni član tima
------ | ----- | ----------- | -------------------
F01 | Registracija i login | Za pristup Event Manageru potrebna je registracija te zatim autentikacija korisnika pomoću registracijskih funkcionalnosti. Aplikacija bi trebala omogućiti korisnicima stvaranje računa i prijavu unosom korisničkog imena i lozinke pomoću podataka definiranih pri registraciji. | Mateo Pikl
F02 | Upravljanje eventima | Korisnici bi trebali moći stvarati, mijenjati i ažurirati nove i postojeće događaje pružanjem pojedinosti kao što su naziv događaja, datum, vrijeme, mjesto i opis. | Mateo Pikl
F03 | Upravljanje ulaznicama | Aplikacija bi trebala podržavati stvaranje i upravljanje ulaznicama, omogućujući organizatorima da postave cijene, količinu i vrste ulaznica (npr. VIP, obične) za svoje događaje. | Mateo Pikl
F04 | Provjera valjanosti karte qr kodom | Osoba zadužena za pregled karata provjera valjanosti karte preko qr koda pri dolasku na event. | Toni Leo Modrić Dragičević
F05 | Dijeljenje eventa na društvenim mrežama | Korisnik može podijeliti željeni događaj na društvenim mrežama. | Toni Leo Modrić Dragičević
F06 | Podsjetnik događaja | Automatska obavijest potvrde prijavljenog/kupljenog događaja. | Toni Leo Modrić Dragičević
F07 | Upravljanje korisničkim profilom | Nakon što korisnik uspješno obavi prijavu u aplikaciju, sustav mu automatski dodjeljuje osobni korisnički profil, temeljen na informacijama koje je unio prilikom registracije. Korisnički profil služi kao centralno mjesto gdje korisnik može pregledavati svoje osobne podatke i postavke. Ovaj funkcionalni zahtjev omogućava korisnicima da potpuno personaliziraju svoj korisnički profil, osiguravajući pritom točnost i ažuriranost svojih podataka. Korisnik će na profilu moći pregledati povijest transakcija i događaja na kojima je bio, kao i aktualne događaje za koje posjeduje karte. | Hrvoje Cutvarić
F08 | Recenzija i ocjenjivanje | Kada korisnik sudjeluje na događaju, aplikacija mu nudi priliku da podijeli svoje dojmove i iskustvo ocjenjivanjem tog događaja. Ove ocjene i recenzije predstavljaju važan način povratnih informacija i pomažu poboljšanju budućih događaja. Ovaj funkcionalni zahtjev osigurava da korisnici mogu aktivno sudjelovati u ocjenjivanju i recenziranju događaja, pružajući korisne informacije organizatorima i drugim korisnicima. | Hrvoje Cutvarić
F09 | Pomoć korisnicima | Ovaj funkcionalni zahtjev omogućuje korisnicima da jednostavno i učinkovito dobiju potrebnu pomoć i podršku kad god im zatreba. Cilj je napraviti jednostavnog chatbot-a koji bi korisnici mogao odgovoriti na neka pitanja. | Hrvoje Cutvarić
F10 | Kupovina ulaznica | Korisnik može odabrati i kupovati ulaznice za event, te može zatražiti povrat. | Antonijo Hamzić
F11 | Pretraživanje po lokaciji | Korisnik može pretraživati evente po lokaciji koja može biti trenutna ili odabrana po želji. | Antonijo Hamzić
F12 | Prikaz nadolazećih evenata | Mogućnost odabira kalendara u aplikaciji gdje su korisniku pokazani svi nadolazeći eventi koje je odabrao. | Antonijo Hamzić


## Tehnologije i oprema
* Github
* Visual Studio (WinForms tehnologija)
* .NET Framework
* Microsoft SSMS
* Visual Paradigm
