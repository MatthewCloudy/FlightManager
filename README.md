# Opis programu [PL]
## Ogólnie
Program został napisany jako zadanie rekrutacyjne na staż do LOT. Szczegóły w osobnym pliku .pdf w repozytorium

## Technologie
W programie wykorzystałem ASP.NET do napisania backendu, solucja jest podzielona na kilka projektów odpowiedzialnych za poszczególne rzeczy. 
Do integracji modelu z bazą danych SQL wykorzystałem Entity Framework. Logowanie zrealizowałem za pomocą platformy Auth0, która generuje nam tokeny JWT.
Frontend przygotowałem w React (ponieważ nie znam jeszcze Angulara), użyłem między innymi bibliotek MUI, Auth0 i biblioteki do nawigacji.

## Uruchomienie
Program możemy uruchomić ustawiając jako projekty startowe projekt FlightManager.Api oraz flightmanager.view. Przed włączeniem w konsoli menedżera pakietów
należy wywołać komendę update-database, któa stworzy bazę danych i wypełni ją przykładowymi wartościami.
