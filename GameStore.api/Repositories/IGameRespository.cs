namespace GameStore.api.Repositories;

public interface IGameRespository
{
    /*
     ** I could Abstract the GameRespository class and use this interface to inject the class in the endpoints
     ** But since there is only Group of endpoints that use the GameRespository class
     ** I decided to use GameRespository class directly in the endpoints using static methods
     ** This way I don't need to create a new instance of GameRespository class in each endpoint
     */
}