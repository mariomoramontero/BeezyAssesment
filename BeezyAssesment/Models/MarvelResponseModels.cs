using System;
using System.Collections.Generic;
using System.Text;

namespace BeezyAssesment.Models
{
    /// <summary>
    /// Types generated automatically by paste special>json as classes. After that only a few changes had to be done here
    /// </summary>

    public class ComicDataWrapper
    {
        public int code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public string etag { get; set; }
        public ComicDataContainer data { get; set; }
    }

    public class ComicDataContainer
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public int total { get; set; }
        public int count { get; set; }
        public Comic[] results { get; set; }
    }

    public class Comic
    {
        public int id { get; set; }
        public int digitalId { get; set; }
        public string title { get; set; }
        public int issueNumber { get; set; }
        public string variantDescription { get; set; }
        public string description { get; set; }
        public object modified { get; set; }
        public string isbn { get; set; }
        public string upc { get; set; }
        public string diamondCode { get; set; }
        public string ean { get; set; }
        public string issn { get; set; }
        public string format { get; set; }
        public int pageCount { get; set; }
        public Textobject[] textObjects { get; set; }
        public string resourceURI { get; set; }
        public Url[] urls { get; set; }
        public Series series { get; set; }
        public Variant[] variants { get; set; }
        public object[] collections { get; set; }
        public Collectedissue[] collectedIssues { get; set; }
        public Date[] dates { get; set; }
        public Price[] prices { get; set; }
        public Thumbnail thumbnail { get; set; }
        public Image[] images { get; set; }
        public Creators creators { get; set; }
        public Characters characters { get; set; }
        public Stories stories { get; set; }
        public EventList events { get; set; }
    }

    public class Series
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Thumbnail
    {
        public string path { get; set; }
        public string extension { get; set; }
        public string FullPath => $"{path}/portrait_xlarge.{extension}";
    }

    public class Creators
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public CreatorList[] items { get; set; }
        //public CreatorList items { get; set; }
        public int returned { get; set; }
    }

    public class CreatorSummary
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string role { get; set; }
    }

    public class Characters
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public StorySummary[] items { get; set; }
        public int returned { get; set; }
    }

    public class ComicSummary
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Stories
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public StorySummary[] items { get; set; }
        public int returned { get; set; }
    }

    public class StorySummary
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class CreatorList
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public object[] items { get; set; }
        public int returned { get; set; }
    }
    public class EventList
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public object[] items { get; set; }
        public int returned { get; set; }
    }

    public class Textobject
    {
        public string type { get; set; }
        public string language { get; set; }
        public string text { get; set; }
    }

    public class Url
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Variant
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Collectedissue
    {
        public string resourceURI { get; set; }
        public string name { get; set; }
    }

    public class Date
    {
        public string type { get; set; }
        public object date { get; set; }
    }

    public class Price
    {
        public string type { get; set; }
        public float price { get; set; }
    }

    public class Image
    {
        public string path { get; set; }
        public string extension { get; set; }
        public string FullPath => $"{path}/portrait_xlarge.{extension}";
        
    }

}
