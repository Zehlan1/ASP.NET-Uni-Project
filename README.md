# Dom Aukcyjny Gier Wideo

Aplikacja pozwala odwiedzającym przeglądać różne gry komputerowe, serie do jakich należą oraz ich wydawców. Zalogowani użytkownicy mogą natomiast dodawać wyżej wymienione elementy oraz tworzyć z nimi aukcje, mogą też licytować w aktywnych aukcjach oraz wykupić je całkowicie.
Konto administratora ma możliwość usuwania oraz edycji aukcji.

## Lista Funkcji

- Tworzenie aukcji oraz wpisów o grach, studiach i seriach gier
- Wyświetlenie szczegółów, edycja oraz usunięcie wpisów
- Rejestracja oraz Logowanie użytkowników
- Licytacja oraz wykup w aktywnych aukcjach
- API pozwalające na odczyt i modyfikację istniejących aukcji

# Instalacja oraz wymagane pakiety

Wszystkie pakiety zostały zainstalowane za pomocą **NuGet**.
Aplikacja korzysta z zewnętrznej bazy danych, w tym przypadku **Microsoft SQL Server**

## Pakiety

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Identity.UI
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- xunit

## Instalacja

- W pliku **appsettings.json** przy polach **DATA SOURCE=** oraz **Server=** wpisujemy adres serwera którego będziemy używać (ustawione początkowo na **localhost**)
- Otwieramy terminal projektu
- Uruchamiamy komendę: **dotnet ef database update --context AppDbContext**
Utworzy ona w bazie danych tabelę z Aukcjami, Grami, Producentami i Seriami Gier
- Uruchamiamy komendę: **dotnet ef database update --context IdentityDbContext**
Utworzy ona w bazie danych tabelę z Użytkownikami
- W sytuacji gdy powyższe dwie komendy nie powiodą się należy użyć komend:
**dotnet ef migrations add InitialCreate --context AppDbContext**
**dotnet ef migrations add InitialIdentity --context IdentityDbContext**
oraz ponownie użyć początkowe komendy

# Dostępni użytkownicy

## Administratorzy

- **Login:** admin1@fake.fake **Hasło:** AdminPassword1!

## Użytkownicy

- **Login:** test1@fake.fake **Hasło:** Password1!
- **Login:** test2@fake.fake **Hasło:** Password2!
- **Login:** test3@fake.fake **Hasło:** Password3!
