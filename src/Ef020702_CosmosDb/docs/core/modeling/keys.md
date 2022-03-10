---
title: Keys - EF Core
description: How to configure keys for entity types when using Entity Framework Core
author: AndriySvyryd
ms.date: 1/10/2021
uid: core/modeling/keys
---
# Keys

A key serves as a unique identifier for each entity instance. Most entities in EF have a single key, which maps to the concept of a *primary key* in relational databases (for entities without keys, see [Keyless entities](xref:core/modeling/keyless-entity-types)). Entities can have additional keys beyond the primary key (see [Alternate Keys](#alternate-keys) for more information).

## Configuring a primary key

By convention, a property named `Id` or `<type name>Id` will be configured as the primary key of an entity.

[!code-csharp[Main](../../../samples/core/Modeling/Keys/KeyId.cs?name=KeyId&highlight=3,11)]

> [!NOTE]
> [Owned entity types](xref:core/modeling/owned-entities) use different rules to define keys.

You can configure a single property to be the primary key of an entity as follows:

### [Data Annotations](#tab/data-annotations)

[!code-csharp[Main](../../../samples/core/Modeling/Keys/DataAnnotations/KeySingle.cs?name=KeySingle&highlight=3)]

### [Fluent API](#tab/fluent-api)

[!code-csharp[Main](../../../samples/core/Modeling/Keys/FluentAPI/KeySingle.cs?name=KeySingle&highlight=4)]

***

You can also configure multiple properties to be the key of an entity - this is known as a composite key. Composite keys can only be configured using the Fluent API; conventions will never set up a composite key, and you can not use Data Annotations to configure one.

[!code-csharp[Main](../../../samples/core/Modeling/Keys/FluentAPI/KeyComposite.cs?name=KeyComposite&highlight=4)]

## Value generation

For non-composite numeric and GUID primary keys, EF Core sets up value generation for you by convention. For example, a numeric primary key in SQL Server is automatically set up to be an IDENTITY column. For more information, see [the documentation on value generation](xref:core/modeling/generated-properties).

## Primary key name

By convention, on relational databases primary keys are created with the name `PK_<type name>`. You can configure the name of the primary key constraint as follows:

[!code-csharp[Main](../../../samples/core/Modeling/Keys/FluentAPI/KeyName.cs?name=KeyName&highlight=5)]

## Key types and values

While EF Core supports using properties of any primitive type as the primary key, including `string`, `Guid`, `byte[]` and others, not all databases support all types as keys. In some cases the key values can be converted to a supported type automatically, otherwise the conversion should be [specified manually](xref:core/modeling/value-conversions).

Key properties must always have a non-default value when adding a new entity to the context, but some types will be [generated by the database](xref:core/modeling/generated-properties). In that case EF will try to generate a temporary value when the entity is added for tracking purposes. After [SaveChanges](/dotnet/api/Microsoft.EntityFrameworkCore.DbContext.SaveChanges) is called the temporary value will be replaced by the value generated by the database.

> [!Important]
> If a key property has its value generated by the database and a non-default value is specified when an entity is added, then EF will assume that the entity already exists in the database and will try to update it instead of inserting a new one. To avoid this, turn off value generation or see [how to specify explicit values for generated properties](xref:core/modeling/generated-properties#overriding-value-generation).

## Alternate Keys

An alternate key serves as an alternate unique identifier for each entity instance in addition to the primary key; it can be used as the target of a relationship. When using a relational database this maps to the concept of a unique index/constraint on the alternate key column(s) and one or more foreign key constraints that reference the column(s).

> [!TIP]
> If you just want to enforce uniqueness on a column, define a unique index rather than an alternate key (see [Indexes](xref:core/modeling/indexes)). In EF, alternate keys are read-only and provide additional semantics over unique indexes because they can be used as the target of a foreign key.

Alternate keys are typically introduced for you when needed and you do not need to manually configure them. By convention, an alternate key is introduced for you when you identify a property which isn't the primary key as the target of a relationship.

[!code-csharp[Main](../../../samples/core/Modeling/Keys/AlternateKey.cs?name=AlternateKey&highlight=12)]

You can also configure a single property to be an alternate key:

[!code-csharp[Main](../../../samples/core/Modeling/Keys/FluentAPI/AlternateKeySingle.cs?name=AlternateKeySingle&highlight=4)]

You can also configure multiple properties to be an alternate key (known as a composite alternate key):

[!code-csharp[Main](../../../samples/core/Modeling/Keys/FluentAPI/AlternateKeyComposite.cs?name=AlternateKeyComposite&highlight=4)]

Finally, by convention, the index and constraint that are introduced for an alternate key will be named `AK_<type name>_<property name>` (for composite alternate keys `<property name>` becomes an underscore separated list of property names). You can configure the name of the alternate key's index and unique constraint:

[!code-csharp[Main](../../../samples/core/Modeling/Keys/FluentAPI/AlternateKeyName.cs?name=AlternateKeyName&highlight=5)]