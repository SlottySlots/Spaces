# EnumUtility

Namespace: SlottyMedia.Components.Partial.Enum

Provides utility functions to convert enums to actual useful values

```csharp
public static class EnumUtility
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [EnumUtility](./slottymedia.components.partial.enum.enumutility.md)

## Methods

### **GetColorClass(ColorWay, Int32)**

Converts ColorWay Enum and typeOfColor into a tailwind css usable class

```csharp
public static string GetColorClass(ColorWay color, int typeOfColor)
```

#### Parameters

`color` [ColorWay](./slottymedia.components.partial.enum.colorway.md)<br>
Naming as defined in tailwind.config.js

`typeOfColor` [Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>
Value range as defined in tailwind.config.js

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Return a tailwind css usable css class

#### Exceptions

[Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)<br>
