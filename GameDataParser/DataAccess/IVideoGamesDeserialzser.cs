public interface IVideoGamesDeserialzser
{
    List<VideoGame> DeserializeFrom(string fileName, string fileContents);
}