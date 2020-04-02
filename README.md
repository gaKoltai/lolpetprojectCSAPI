# Summoner Searcher API

## Goals of the project:

- This is an API to consume and expose data from the RIOT Games API to the [Summoner Searcher](https://github.com/gaKoltai/lolpetproject) project.
- Get account data from users (summoners).
- Get match history of summoners.
- Get ranked and misc. statistical data of summoners.

## Motivations for building this project:

- Familiarize myself with the ASP.Net Core.
- Practice design patterns and syntax.
- Provide a source of data for the [Summoner Searcher](https://github.com/gaKoltai/lolpetproject) project as a first attempt at building a "full-stack" application alone.
- Practice writing API calls from a back-end environment (in C#).


## In order to run the full app (frontend and backend) :

- Please download the front-end page from (and follow readme.md)  : https://github.com/gaKoltai/lolpetproject
- Make sure your device has the latest versions of [.NET Core installed](https://dotnet.microsoft.com/download).
- Make sure the front-end server is making calls to the port the API is being hosted on.
- Change the API key in StaticUtil/Util.cs to your own key and dont forget to UPDATE THIS EVERY 24 hours. Get your own API key at the [RIOT Games Developer Portal](https://developer.riotgames.com/).


## Technologies used:

- ASP.NET Core API.
- C#.
