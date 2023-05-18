

Sword baseSword = new Sword(SwordMaterial.Iron, Gemstone.None, 10, 4);

Sword revisedSword = baseSword with { SwordMaterial = SwordMaterial.Steel, Gemstone = Gemstone.Amber };

Sword bigSword = baseSword with { Length = 15.5f, CrossguardWidth = 6.25f };

Console.WriteLine($"{baseSword}\n{revisedSword}\n{bigSword}");



public record Sword(SwordMaterial SwordMaterial, Gemstone Gemstone, float Length, float CrossguardWidth);

public enum SwordMaterial {Wood, Bronze, Iron, Steel, Binarium}
public enum Gemstone {Emerald, Amber, Sapphire, Diamond, Bitstone, None}