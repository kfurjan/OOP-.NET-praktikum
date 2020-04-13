# OOP-.NET-praktikum
Projektni zadatak za kolegij  _Objektno orijentirano programiranje - praktikum u .NET okolini_

## Opis projekta
Aplikacija se sastoji od tri projekta (Windows Forms, WPF, Class Library) zadužena za prikaz statistika sa Svjetskih nogometnih prvenstava za žene i muškarce 2018. i 2019. godine. Aplikacija povlači podatke sa API-a, https://worldcup.sfg.io/ i https://world-cup-json-2018.herokuapp.com/

## Windows Forms aplikacija
- ako se neka operacija ne izvršava trenutno, potrebno je prikazati animaciju učitavanja
- prilikom pokretanja aplikacije prikazuje se forma u kojoj je potrebno postaviti željeno prvenstno i jezik aplikacije
- potrebno odabrati omiljenu reprezentaciju
- potrebno odabrati tri omiljena igrača iz reprezentacije
- potrebno prikazati slike igrača iz reprezentacije
- prikazati rang liste po kriterijima: broj zabijenih golova, broj žutih kartona
- prikazati rang list broja posijetitelja

## Windows Presentation Foundation (WPF) aplikacija
- prilikom pokretanja aplikacije prikazuje se forma u kojoj je potrebno postaviti željeno prvenstno, jezik aplikacije i veličinu prozora
- aplikacija uvijek mora biti responzivna
- prikazuje osnovne informacije o odabranoj repreznetaciji
- iscrtava prikaz početne postave ("starting eleven")
- odabirom igrača se prikazuje prozor s informacijama o igraču
- postavljanje postavki moguće je i kroz prozor "Postavke"

## Podatkvni sloj (Class Library)
- dohvaćanje podataka s navedenog API-a (asinkrono)
- parsiranje i mapiranje dohvaćenih podataka
- pripremu podataka za korištenje u klijentskim aplikacijama
- pohranu podataka u tekstualne datoteke
- čitanje podataka iz tekstualnih datoteka
