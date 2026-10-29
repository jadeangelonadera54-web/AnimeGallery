using System;
using System.Collections.Generic;

namespace AnimeGallery.Models;

public class AnimeCharacter
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string JapaneseName { get; set; } = string.Empty;
    public string AnimeSeries { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Affiliation { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string FullBio { get; set; } = string.Empty;
    public string SignatureAbility { get; set; } = string.Empty;
    public List<string> Abilities { get; set; } = new();
    public string NotableQuote { get; set; } = string.Empty;
    
    // Stats (0.0 to 1.0 for progress bars)
    public double PowerLevel { get; set; }
    public double AgilityLevel { get; set; }
    public double IntelligenceLevel { get; set; }
    public double DurabilityLevel { get; set; }

    public string PowerDisplay => $"{(int)(PowerLevel * 100)}%";
    public string AgilityDisplay => $"{(int)(AgilityLevel * 100)}%";
    public string IntelligenceDisplay => $"{(int)(IntelligenceLevel * 100)}%";
    public string DurabilityDisplay => $"{(int)(DurabilityLevel * 100)}%";
}
