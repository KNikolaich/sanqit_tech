namespace CreditCalculator.API.Converters;

using System.Text.Json;
using System.Text.Json.Serialization;

internal class RoundDoubleJsonConverter(string format = "0.00") : JsonConverter<double>
{
    public override double Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    ) =>
        reader.GetDouble();

    public override void Write(
        Utf8JsonWriter writer,
        double value,
        JsonSerializerOptions options
    ) =>
        writer.WriteNumberValue(double.Parse(value.ToString(format)));
}