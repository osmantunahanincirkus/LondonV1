using System.Text.Json.Serialization;

namespace London.Api.Models.BookRestApi;

public class Class
{
	//		var client = new HttpClient();
	//		var request = new HttpRequestMessage(HttpMethod.Get, "http://openlibrary.org/works/OL27258W/editions.json?limit=5");
	//		var response = await client.SendAsync(request);
	//		response.EnsureSuccessStatusCode();
	//Console.WriteLine(await response.Content.ReadAsStringAsync());


}

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record Root(
[property: JsonPropertyName("links")] Links Links,
[property: JsonPropertyName("size")] int Size,
[property: JsonPropertyName("entries")] IReadOnlyList<Entry> Entries);

public record Author(
	[property: JsonPropertyName("key")] string Key
);

public record Classifications(

);

public record Created(
	[property: JsonPropertyName("type")] string Type,
	[property: JsonPropertyName("value")] DateTime Value
);

public record Entry(
	[property: JsonPropertyName("type")] Type Type,
	[property: JsonPropertyName("authors")] IReadOnlyList<Author> Authors,
	[property: JsonPropertyName("isbn_13")] IReadOnlyList<string> Isbn13,
	[property: JsonPropertyName("languages")] IReadOnlyList<Language> Languages,
	[property: JsonPropertyName("pagination")] string Pagination,
	[property: JsonPropertyName("publish_date")] string PublishDate,
	[property: JsonPropertyName("publishers")] IReadOnlyList<string> Publishers,
	[property: JsonPropertyName("source_records")] IReadOnlyList<string> SourceRecords,
	[property: JsonPropertyName("subjects")] IReadOnlyList<string> Subjects,
	[property: JsonPropertyName("title")] string Title,
	[property: JsonPropertyName("full_title")] string FullTitle,
	[property: JsonPropertyName("works")] IReadOnlyList<Work> Works,
	[property: JsonPropertyName("key")] string Key,
	[property: JsonPropertyName("covers")] IReadOnlyList<int> Covers,
	[property: JsonPropertyName("latest_revision")] int LatestRevision,
	[property: JsonPropertyName("revision")] int Revision,
	[property: JsonPropertyName("created")] Created Created,
	[property: JsonPropertyName("last_modified")] LastModified LastModified,
	[property: JsonPropertyName("isbn_10")] IReadOnlyList<string> Isbn10,
	[property: JsonPropertyName("physical_format")] string PhysicalFormat,
	[property: JsonPropertyName("identifiers")] Identifiers Identifiers,
	[property: JsonPropertyName("classifications")] Classifications Classifications,
	[property: JsonPropertyName("number_of_pages")] int? NumberOfPages,
	[property: JsonPropertyName("series")] IReadOnlyList<string> Series,
	[property: JsonPropertyName("local_id")] IReadOnlyList<string> LocalId,
	[property: JsonPropertyName("copyright_date")] string CopyrightDate,
	[property: JsonPropertyName("description")] string Description,
	[property: JsonPropertyName("notes")] string Notes,
	[property: JsonPropertyName("translation_of")] string TranslationOf,
	[property: JsonPropertyName("translated_from")] IReadOnlyList<TranslatedFrom> TranslatedFrom,
	[property: JsonPropertyName("subtitle")] string Subtitle
);

public record Identifiers(

);

public record Language(
	[property: JsonPropertyName("key")] string Key
);

public record LastModified(
	[property: JsonPropertyName("type")] string Type,
	[property: JsonPropertyName("value")] DateTime Value
);

public record Links(
	[property: JsonPropertyName("self")] string Self,
	[property: JsonPropertyName("work")] string Work,
	[property: JsonPropertyName("next")] string Next
);

public record TranslatedFrom(
	[property: JsonPropertyName("key")] string Key
);

public record Type(
	[property: JsonPropertyName("key")] string Key
);

public record Work(
	[property: JsonPropertyName("key")] string Key
);
