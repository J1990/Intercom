# Prerequisites
DotNet Core -> .NET SDK 3.1.300

.NET Runtime 3.1.14

# Commands for execution
root> git clone https://github.com/J1990/Intercom.git

root>  git pull

root>cd Intercom

root\Intercom> dotnet build src\App\App.csproj

root\Intercom> dotnet run --project src\App\App.csproj

# Running Tests
root\Intercom> dotnet test tests\BusinessLayer\Intercom.BusinessLayer.Tests.csproj

root\Intercom> dotnet test tests\DataAccess\Intercom.DataAccess.Tests.csproj
