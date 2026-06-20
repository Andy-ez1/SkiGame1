# SkiGame1

# Ski Game - 3. Mājas darbs

Slēpošanas spēle, kurā spēlētājs brauc pa nogāzi, izvairās no šķēršļiem un iziet
slaloma trasi ar starta, soda un finiša karodziņiem. Mērķis - sasniegt finišu pēc
iespējas ātrāk un tikt labāko laiku sarakstā.

## Vadība
- A / D vai kreisā/labā bultiņa - pagriezt slēpotāju
- Spēlētājs paātrinās automātiski pa nogāzi uz leju

## Izpildītie uzdevumi
1. Līmeņa izveide - nogāze, šķēršļi (koki, akmeņi), vide
2. Spēlētāja kontrole - Rigidbody kustība, pagriešana, rotācijas ierobežošana
3. Sadursmes ar šķēršļiem - event sistēma sadursmju apstrādei
4. Atmešana atpakaļ pēc sadursmes - knockback + īslaicīga kustības bloķēšana
5. Sacensību loģika - starts, soda karodziņi (slaloms), finišs
6. Laika un rekorda parādīšana UI - TIME un BEST TIME teksti
7. Labākā laika saglabāšana - PlayerPrefs

## Papildinājumi
- Līderu saraksta vizualizācija - top 5 labākie laiki tiek saglabāti PlayerPrefs
  un parādīti ekrānā (TOP TIMES). Saraksts atjaunojas uzreiz pēc finiša.
- Skaņas efekti - sadursmes skaņa, atskaņojot pa akmeni.

## Tehniskais
- Unity, C#
- Labāko laiku glabāšana caur PlayerPrefs (Leaderboard.cs)
- Event sistēma starta/finiša/soda loģikai
