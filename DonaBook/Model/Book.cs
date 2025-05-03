using System;
using System.Collections.Generic;

namespace Kpl_tubes.Model
{
    // ENUMS
    public enum Genre
    {
        Fiction,
        NonFiction,
        ScienceFiction,
        Fantasy,
        Mystery,
        Romance,
        Horror,
        Biography,
        SelfHelp,
        History,
        Unknown
    }

    public enum Category
    {
        AnakAnak,
        Remaja,
        Dewasa,
        Pendidikan,
        Lainnya
    }

    public enum BookCondition
    {
        Baru,
        BekasBaik,
        BekasRusak
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public Genre Genre { get; set; }
        public Category Category { get; set; }
        public BookCondition Condition { get; set; }

        public int Quantity { get; set; }
        public bool IsVerified { get; set; }
        public string? Review { get; set; }
        public int Rating { get; set; }

        // Constructor tanpa parameter untuk Swagger dan deserialisasi
        public Book() { }

        // Constructor utama dengan logika rating default
        public Book(string title, string publisher, Genre genre, string author, Category category, BookCondition condition, int quantity, int donorId)
        {
            Title = title;
            Publisher = publisher;
            Genre = genre;
            Author = author;
            Category = category;
            Condition = condition;
            Quantity = quantity;
            IsVerified = false;
            Rating = GenreDefaultRatings.ContainsKey(genre) ? GenreDefaultRatings[genre] : 0;
        }

        // Table-driven rating default berdasarkan genre
        private static readonly Dictionary<Genre, int> GenreDefaultRatings = new()
        {
            { Genre.Fiction, 5 },
            { Genre.NonFiction, 4 },
            { Genre.ScienceFiction, 4 },
            { Genre.Fantasy, 5 },
            { Genre.Mystery, 4 },
            { Genre.Romance, 3 },
            { Genre.Horror, 4 },
            { Genre.Biography, 4 },
            { Genre.SelfHelp, 3 },
            { Genre.History, 4 }
        };
    }
}
