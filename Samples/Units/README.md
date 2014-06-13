# Units Sample

A .NET 4.0 Windows Forms application that demonstrates basics of working with `opt.Units` namespaces.
References `opt.Domain` and `opt.Core` libraries.

Tasks covered by this sample:
1. Working with different unit types.
  1. `IUnit` and `IPrefixedUnit` interfaces & `Unit` and `PrefixedUnit` classes that implement these interfaces.
  2. Custom unit - `IMyUnit` interface and its implementation `MyUnit`, derived from `UnitBase`.
2. Working with `UnitCollection` class - adding units, accessing units by name.
3. Defining units.
  1. Loading units from external source.
  2. Defining units in code.
4. Defining unit conversions.
  1. Loading conversion from external source.
  2. Defining custom conversions in code.
  3. Using prefixed units conversions.
5. Working with conversions and converters.
  1. Utilizing prefixed unit conversion provider.
  2. Utilizing `UnitConversionDictionary` - to store custom conversions and use it as conversions provider.
  3. Using `AggregateUnitConverter<T>` as a single access point to unit conversion.
