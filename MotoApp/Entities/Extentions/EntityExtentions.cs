
using System.Text.Json;

namespace MotoApp.Entities.Extentions;

public static class EntityExtentions
{
    //serializacja
    //dezserializacja


    //kopia naszego objekta
    public static T? Copy<T>(this T itemToCopy) 
        where T :IEntity
    {
        var json = JsonSerializer.Serialize<T>(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);
    }



}

