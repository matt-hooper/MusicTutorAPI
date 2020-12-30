"# MusicTutorAPI" 

# Add migration
dotnet ef --startup-project MusicTutorAPI.Api/MusicTutorAPI.Api.csproj migrations add InitialModel -p MusicTutorAPI.Data/MusicTutorAPI.Data.csproj

# Remove migration
dotnet ef --startup-project MusicTutorAPI.Api/MusicTutorAPI.Api.csproj migrations remove -p MusicTutorAPI.Data/MusicTutorAPI.Data.csproj

# Update database
dotnet ef --startup-project MusicTutorAPI.Api/MusicTutorAPI.Api.csproj database update

# Drop the database
dotnet ef --startup-project MusicTutorAPI.Api/MusicTutorAPI.Api.csproj database drop

# Rollback database - Update the database to a previous successful migration
dotnet ef --startup-project MusicTutorAPI.Api/MusicTutorAPI.Api.csproj database update APreviousMigration -p MusicTutorAPI.Data/MusicTutorAPI.Data.csproj

dotnet ef --startup-project MusicTutorAPI.Api/MusicTutorAPI.Api.csproj database update InitialModel -p MusicTutorAPI.Data/MusicTutorAPI.Data.csproj


# Add HealthChecks
https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-5.0

# EF Core GenericServices
https://github.com/JonPSmith/EfCore.GenericServices
