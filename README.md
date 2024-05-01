# Vue ärirakendus
Tere! See on minu .net programmeerija prooviülesanne. See Vue rakendus võimaldab lisada, muuta ja vaadata üritusi ning nende osalejaid. Tegu on minu kolmanda projektifailiga, ehk kahjuks mul puudub pikk commitide list, kust oleks võimalik töö käiku täpsemalt jälgida.

# Failid

`src/components` kaustas on kaks peamist komponenti: `EventForm` ja `HomePage`. `EventForm` komponent on loodud ürituste lisamiseks. `App` komponent on peamiseks komponendiks, kus on kujunduse ja vormi põhiline osa, lisaks logode ja päisega väljad. `views`kaustas olev AddParticipant on loodud osavõtjate kuvamiseks ja lisamiseks. ParticipantDetailsPage on loodud osaleja andmete ülevaatamiseks ja andmete muutmiseks.

## Faili avamiseks

Selle rakenduse paigaldamiseks ja kohalikul masinal käitamiseks järgige järgmisi samme:
1. Klooni repositoorium oma kohalikku masinasse:
git clone https://github.com/camaar2/RIK_Testtoo.git
2. Navigeeri projekti kausta:
cd eventapp
3. Paigalda sõltuvused:
npm install (selleks oleks vaja alla laadida Node.js node package manager(npm))
pnpm install
4. Käivita arendusserver:
pnpm run dev
5. Käivita backend, run-ides projekti
6. Ava oma veebibrauser ja külasta `http://localhost:5173`, et vaadata rakendust.

## Kasutamine

Rakenduse käivitamisel avaneb esileht, kus on välja toodud tulevased ja toimunud üritused. Tulevastel üritustel on võimalik vaadata osavõtjaid ja rea lõpus oleva ristikesega üritus kustutada. Samuti all nurgas asub nupp LISA ÜRITUS, mis viib ürituse lisamise lehele. Osavõtjate lehel on võimalik vaadata osaleja andmeid detailselt, vajutades nupule VAATA. Samuti on võimalik andmeid antud lehel muuta.
