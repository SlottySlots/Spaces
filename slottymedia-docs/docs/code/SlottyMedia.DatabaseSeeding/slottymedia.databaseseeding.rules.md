# Rules

Namespace: SlottyMedia.DatabaseSeeding

The Rules class contains methods to create Faker objects with predefined rules for generating fake Dao objects.

```csharp
public class Rules
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Rules](./slottymedia.databaseseeding.rules.md)

## Constructors

### **Rules()**

```csharp
public Rules()
```

## Methods

### **UserRules()**

Creates the rules for generating fake UserDao objects.
 - UserId: Randomly generated GUID.
 - RoleId: Fixed GUID value.
 - UserName: Randomly generated internet username.
 - Description: Randomly generated sentence.
 - ProfilePic: Randomly generated long value between 1 and 1000.
 - CreatedAt: Randomly generated past date.

```csharp
public Faker<UserDao> UserRules()
```

#### Returns

Faker&lt;UserDao&gt;<br>
A Faker&lt;\&gt; object with predefined rules.

### **ForumRules(List&lt;Guid&gt;)**

Creates the rules for generating fake ForumDao objects.
 - ForumId: Randomly generated GUID.
 - CreatorUserId: Randomly selected from provided user IDs.
 - ForumTopic: Randomly generated sentence.
 - CreatedAt: Randomly generated past date.

```csharp
public Faker<ForumDao> ForumRules(List<Guid> userIds)
```

#### Parameters

`userIds` [List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of user IDs to associate with the forums.

#### Returns

Faker&lt;ForumDao&gt;<br>
A Faker&lt;\&gt; object with predefined rules.

### **PostRules(List&lt;Guid&gt;, List&lt;Guid&gt;)**

Creates the rules for generating fake PostsDao objects.
 - PostId: Randomly generated GUID.
 - UserId: Randomly selected from provided user IDs.
 - ForumId: Randomly selected from provided forum IDs.
 - Headline: Randomly generated sentence.
 - Content: Randomly generated paragraphs.
 - CreatedAt: Randomly generated past date.

```csharp
public Faker<PostsDao> PostRules(List<Guid> userIds, List<Guid> forumIds)
```

#### Parameters

`userIds` [List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of user IDs to associate with the posts.

`forumIds` [List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of forum IDs to associate with the posts.

#### Returns

Faker&lt;PostsDao&gt;<br>
A Faker&lt;\&gt; object with predefined rules.

### **CommentRules(List&lt;Guid&gt;, List&lt;Guid&gt;)**

Creates the rules for generating fake CommentDao objects.
 - CommentId: Randomly generated GUID.
 - CreatorUserId: Randomly selected from provided user IDs.
 - PostId: Randomly selected from provided post IDs.
 - Content: Randomly generated paragraph.
 - CreatedAt: Randomly generated past date.

```csharp
public Faker<CommentDao> CommentRules(List<Guid> userIds, List<Guid> postIds)
```

#### Parameters

`userIds` [List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of user IDs to associate with the comments.

`postIds` [List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of post IDs to associate with the comments.

#### Returns

Faker&lt;CommentDao&gt;<br>
A Faker&lt;\&gt; object with predefined rules.

### **FollowerUserRelationRules(List&lt;Guid&gt;)**

Creates the rules for generating fake FollowerUserRelationDao objects.
 - FollowerUserRelationId: Randomly generated GUID.
 - FollowerUserId: Randomly selected from provided user IDs, ensuring no duplicate relations.
 - FollowedUserId: Randomly selected from provided user IDs, ensuring no duplicate relations.
 - CreatedAt: Randomly generated past date.

```csharp
public Faker<FollowerUserRelationDao> FollowerUserRelationRules(List<Guid> userIds)
```

#### Parameters

`userIds` [List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of user IDs to associate with the follower relations.

#### Returns

Faker&lt;FollowerUserRelationDao&gt;<br>
A Faker&lt;\&gt; object with predefined rules.

#### Exceptions

[ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception)<br>
Thrown when less than two user IDs are provided.

### **UserLikePostRelationRules(List&lt;Guid&gt;, List&lt;Guid&gt;)**

Creates the rules for generating fake UserLikePostRelationDao objects.
 - UserLikePostRelationId: Randomly generated GUID.
 - UserId: Randomly selected from provided user IDs, ensuring no duplicate relations.
 - PostId: Randomly selected from provided post IDs, ensuring no duplicate relations.
 - CreatedAt: Randomly generated past date.

```csharp
public Faker<UserLikePostRelationDao> UserLikePostRelationRules(List<Guid> userIds, List<Guid> postIds)
```

#### Parameters

`userIds` [List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of user IDs to associate with the like relations.

`postIds` [List&lt;Guid&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
A list of post IDs to associate with the like relations.

#### Returns

Faker&lt;UserLikePostRelationDao&gt;<br>
A Faker&lt;\&gt; object with predefined rules.
