# Units Sample

A .NET 4.0 Windows Forms application that demonstrates basics of working with `opt.Units` namespaces.
References `opt.Domain` and `opt.Core` libraries.

Tasks covered by this sample:

1. Working with different unit types.
  - `IUnit` and `IPrefixedUnit` interfaces & `Unit` and `PrefixedUnit` classes that implement these interfaces.
  - Custom unit - `IMyUnit` interface and its implementation `MyUnit`, derived from `UnitBase`.

2. Working with `UnitCollection` class - adding units, accessing units by name.

3. Defining units.
  - Loading units from external source.
  - Defining units in code.

4. Defining unit conversions.
  - Loading conversion from external source.
  - Defining custom conversions in code.
  - Using prefixed units conversions.

5. Working with conversions and converters.
  - Utilizing prefixed unit conversion provider.
  - Utilizing `UnitConversionDictionary` - to store custom conversions and use it as conversions provider.
  - Using `AggregateUnitConverter<T>` as a single access point to unit conversion.
