using SlottyMedia.Database;

namespace SlottyMedia.DatabaseSeeding;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Seeding database with random data...");
        var client = InitializeSupabaseClient.GetSupabaseClient();
        var databaseActions = new DatabaseActions(client);
        var rules = new Rules();

        var countUser = 10;

        // Generate random data
        Console.WriteLine("Generating Rules.");
        var userFaker = rules.UserRules();
        var forumFaker = rules.ForumRules(userFaker);
        var postFaker = rules.PostRules(userFaker, forumFaker);
        var commentFaker = rules.CommentRules(userFaker, postFaker);
        var followerUserRelationFaker = rules.FollowerUserRelationRules(userFaker);
        var userLikePostRelationFaker = rules.UserLikePostRelationRules(userFaker, postFaker);
        Console.WriteLine("Rules generated.");

        // Generate and insert users
        Console.WriteLine("Generating and seeding random user data.");
        var users = userFaker.Generate(countUser);
        var userIds = new List<string>();
        for (int i = 0; i < users.Count; i++)
        {
            var user = await databaseActions.Insert(users[i]);
            userIds.Add(user.UserId);
            Console.WriteLine("User seeded: " + user.UserName);
        }
        Console.WriteLine("Database seeded with random user data.");

        // Generate and insert forums
        Console.WriteLine("Generating and seeding random forum data.");
        var forums = forumFaker.Generate(countUser*2);
        var forumIds = new List<string>();
        for (int i = 0; i < forums.Count; i++)
        {
            forums[i].CreatorUserId = userIds[i % userIds.Count];
            var forum = await databaseActions.Insert(forums[i]);
            forumIds.Add(forum.ForumId);
            Console.WriteLine("Forum seeded: " + forum.ForumTopic);
        }
        Console.WriteLine("Database seeded with random forum data.");

        // Generate and insert posts
        Console.WriteLine("Generating and seeding random post data.");
        var posts = postFaker.Generate(countUser*5);
        var postIds = new List<string>();
        for (int i = 0; i < posts.Count; i++)
        {
            posts[i].UserId = userIds[i % userIds.Count];
            posts[i].ForumId = forumIds[i % forumIds.Count];
            var post = await databaseActions.Insert(posts[i]);
            postIds.Add(post.PostId);
            Console.WriteLine("Post seeded: " + post.Headline);
        }
        Console.WriteLine("Database seeded with random post data.");

        // Generate and insert comments
        Console.WriteLine("Generating and seeding random comment data.");
        var comments = commentFaker.Generate(countUser*10);
        for (int i = 0; i < comments.Count; i++)
        {
            comments[i].CreatorUserId = userIds[i % userIds.Count];
            comments[i].PostId = postIds[i % postIds.Count];
            var comment = await databaseActions.Insert(comments[i]);
            Console.WriteLine("Comment seeded: " + comment.Content);
        }
        Console.WriteLine("Database seeded with random comment data.");

        // Generate and insert follower user relations
        Console.WriteLine("Generating and seeding random follower user relation data.");
        var followerUserRelations = followerUserRelationFaker.Generate(countUser*2);
        for (int i = 0; i < followerUserRelations.Count; i++)
        {
            followerUserRelations[i].FollowerUserId = userIds[i % userIds.Count];
            followerUserRelations[i].FollowedUserId = userIds[(i + 1) % userIds.Count];
            var followerUserRelation = await databaseActions.Insert(followerUserRelations[i]);
            Console.WriteLine("FollowerUserRelation seeded. Follower: " + followerUserRelation.FollowerUserId + " Followed: " + followerUserRelation.FollowedUserId);
        }
        Console.WriteLine("Database seeded with random follower user relation data.");

        // Generate and insert user like post relations
        Console.WriteLine("Generating and seeding random user like post relation data.");
        var userLikePostRelations = userLikePostRelationFaker.Generate(countUser*5);
        for (int i = 0; i < userLikePostRelations.Count; i++)
        {
            userLikePostRelations[i].UserId = userIds[i % userIds.Count];
            userLikePostRelations[i].PostId = postIds[i % postIds.Count];
            var userLikePostRelation = await databaseActions.Insert(userLikePostRelations[i]);
            Console.WriteLine("UserLikePostRelation seeded. User: " + userLikePostRelation.UserId + " Post: " + userLikePostRelation.PostId);
        }
        Console.WriteLine("Database seeded with random user like post relation data.");

        Console.WriteLine("Database seeded with random data.");
    }
}