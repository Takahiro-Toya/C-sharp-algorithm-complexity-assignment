﻿using System;
namespace CAB301Assignment {
    public enum Genre {
        Drama,
        Adventure,
        Family,
        Action,
        SciFi,
        Comedy,
        Animated,
        Thriller,
        Other
    }

    public static class GenreMethods {
        public static string toString(this Genre genre) {
            return genre switch
            {
                Genre.Drama => "Drama",
                Genre.Adventure => "Adventure",
                Genre.Family => "Family",
                Genre.Action => "Action",
                Genre.SciFi => "Sci-Fi",
                Genre.Comedy => "Comedy",
                Genre.Animated => "Drama",
                Genre.Thriller => "Thriller",
                Genre.Other => "Other",
                _ => "Other"
            };
        }
    }

    public enum Classification {
        General,
        ParentalGuidance,
        Mature,
        MatureAccompanied,
    }

    public static class ClassificationMethods {
        public static string toString(this Classification classification) {
            return classification switch
            {
                Classification.General => "General (G)",
                Classification.ParentalGuidance => "Parental Guidance (PG)",
                Classification.Mature => "Mature (M15+)",
                Classification.MatureAccompanied => "Mature Accompanied (MA15+)",
                _ => "General (G)"
            };
        }
    }


    public enum AppStatus {
        Exit,
        MainMenu,
        StaffMenu,
        MemberMenu,
        Staff1,
        Staff2,
        Staff3,
        Staff4,
        Member1,
        Member2,
        Member3,
        Member4,
        Member5
    }
}
