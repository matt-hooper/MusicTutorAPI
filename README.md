"# MusicTutorAPI" 

# Add migration
dotnet ef --startup-project MusicTutorAPI.Api/MusicTutorAPI.Api.csproj migrations add InitialModel -p MusicTutorAPI.Data/MusicTutorAPI.Data.csproj

# Remove migration
dotnet ef --startup-project MusicTutorAPI.Api/MusicTutorAPI.Api.csproj migrations remove -p MusicTutorAPI.Data/MusicTutorAPI.Data.csproj

# Update database
dotnet ef --startup-project MusicTutorAPI.Api/MusicTutorAPI.Api.csproj database update
