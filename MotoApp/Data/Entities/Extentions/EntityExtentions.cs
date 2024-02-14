
using System.Text.Json;
using MotoApp.Data.Entities;

namespace MotoApp.Data.Entities.Extentions;

public static class EntityExtentions
{
    //serializacja
    //dezserializacja


    //kopia naszego objekta
    public static T? Copy<T>(this T itemToCopy)
        where T : IEntity
    {
        var json = JsonSerializer.Serialize(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);
    }



}

