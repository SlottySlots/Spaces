
SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

CREATE EXTENSION IF NOT EXISTS "pgsodium" WITH SCHEMA "pgsodium";

COMMENT ON SCHEMA "public" IS 'standard public schema';

CREATE EXTENSION IF NOT EXISTS "pg_graphql" WITH SCHEMA "graphql";

CREATE EXTENSION IF NOT EXISTS "pg_stat_statements" WITH SCHEMA "extensions";

CREATE EXTENSION IF NOT EXISTS "pgcrypto" WITH SCHEMA "extensions";

CREATE EXTENSION IF NOT EXISTS "pgjwt" WITH SCHEMA "extensions";

CREATE EXTENSION IF NOT EXISTS "supabase_vault" WITH SCHEMA "vault";

CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA "extensions";

SET default_tablespace = '';

SET default_table_access_method = "heap";

CREATE TABLE IF NOT EXISTS "public"."Comment" (
    "commentID" "uuid" DEFAULT "gen_random_uuid"() NOT NULL,
    "parent_commentID" "uuid",
    "creator_UserID" "uuid" NOT NULL,
    "corresponding_PostID" "uuid" NOT NULL,
    "content" character varying NOT NULL,
    "created_at" timestamp with time zone DEFAULT "now"() NOT NULL
);

ALTER TABLE "public"."Comment" OWNER TO "postgres";

COMMENT ON TABLE "public"."Comment" IS 'Comments which may be provided by users to a corresponding post (nesting comments e.g. answers on comments may be allowed in the future)';

CREATE TABLE IF NOT EXISTS "public"."Follower_User_Relation" (
    "followerUserRelationID" "uuid" DEFAULT "gen_random_uuid"() NOT NULL,
    "userIsFollowing" "uuid" NOT NULL,
    "userIsFollowed" "uuid" NOT NULL,
    "created_at" timestamp with time zone DEFAULT "now"() NOT NULL
);

ALTER TABLE "public"."Follower_User_Relation" OWNER TO "postgres";

COMMENT ON TABLE "public"."Follower_User_Relation" IS 'A linking table which provided information for the following / follower relation of users';

CREATE TABLE IF NOT EXISTS "public"."Forum" (
    "forumID" "uuid" DEFAULT "gen_random_uuid"() NOT NULL,
    "creator_userID" "uuid",
    "forumTopic" character varying NOT NULL,
    "created_at" timestamp with time zone DEFAULT "now"() NOT NULL
);

ALTER TABLE "public"."Forum" OWNER TO "postgres";

COMMENT ON TABLE "public"."Forum" IS 'The root of any post e.g. a computer science forum providing posts related to computer science';

CREATE TABLE IF NOT EXISTS "public"."Posts" (
    "postID" "uuid" DEFAULT "gen_random_uuid"() NOT NULL,
    "associated_forumID" "uuid" NOT NULL,
    "creator_userID" "uuid" NOT NULL,
    "headline" character varying NOT NULL,
    "content" character varying,
    "created_at" timestamp with time zone DEFAULT "now"() NOT NULL
);

ALTER TABLE "public"."Posts" OWNER TO "postgres";

COMMENT ON TABLE "public"."Posts" IS 'Posts which may be created under a specific topic (forum)';

CREATE TABLE IF NOT EXISTS "public"."Role" (
    "roleID" "uuid" DEFAULT "gen_random_uuid"() NOT NULL,
    "role" character varying,
    "description" character varying,
    "created_at" timestamp with time zone DEFAULT "now"() NOT NULL
);

ALTER TABLE "public"."Role" OWNER TO "postgres";

COMMENT ON TABLE "public"."Role" IS 'Represents the role of a user e.g. a normal user, or a admin of SlottyMedia';

CREATE TABLE IF NOT EXISTS "public"."User" (
    "userID" "uuid" NOT NULL,
    "userName" character varying NOT NULL,
    "description" character varying,
    "profilePic" bigint,
    "created_at" timestamp with time zone DEFAULT "now"() NOT NULL,
    "roleID" "uuid" NOT NULL,
    "email" "text"
);

ALTER TABLE "public"."User" OWNER TO "postgres";

COMMENT ON TABLE "public"."User" IS 'Represents a user after its login';

CREATE TABLE IF NOT EXISTS "public"."User_Like_Post_Relation" (
    "userLikePostRelationID" "uuid" DEFAULT "gen_random_uuid"() NOT NULL,
    "userID" "uuid" NOT NULL,
    "postID" "uuid" NOT NULL,
    "created_at" timestamp with time zone DEFAULT "now"() NOT NULL
);

ALTER TABLE "public"."User_Like_Post_Relation" OWNER TO "postgres";

COMMENT ON TABLE "public"."User_Like_Post_Relation" IS 'A linking table which provides information for the like / dislike ratio of a post.';

ALTER TABLE ONLY "public"."Comment"
    ADD CONSTRAINT "Comment_pkey" PRIMARY KEY ("commentID");

ALTER TABLE ONLY "public"."Follower_User_Relation"
    ADD CONSTRAINT "Follower_User_Relation_pkey" PRIMARY KEY ("followerUserRelationID");

ALTER TABLE ONLY "public"."Forum"
    ADD CONSTRAINT "Forum_pkey" PRIMARY KEY ("forumID");

ALTER TABLE ONLY "public"."Posts"
    ADD CONSTRAINT "Posts_pkey" PRIMARY KEY ("postID");

ALTER TABLE ONLY "public"."Role"
    ADD CONSTRAINT "Role_pkey" PRIMARY KEY ("roleID");

ALTER TABLE ONLY "public"."User_Like_Post_Relation"
    ADD CONSTRAINT "User_Like_Post_Relation_pkey" PRIMARY KEY ("userLikePostRelationID");

ALTER TABLE ONLY "public"."User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("userID");

ALTER TABLE ONLY "public"."Comment"
    ADD CONSTRAINT "Comment_correspodning_PostID_fkey" FOREIGN KEY ("corresponding_PostID") REFERENCES "public"."Posts"("postID");

ALTER TABLE ONLY "public"."Comment"
    ADD CONSTRAINT "Comment_creator_UserID_fkey" FOREIGN KEY ("creator_UserID") REFERENCES "public"."User"("userID");

ALTER TABLE ONLY "public"."Comment"
    ADD CONSTRAINT "Comment_parent_commentID_fkey" FOREIGN KEY ("parent_commentID") REFERENCES "public"."Comment"("commentID");

ALTER TABLE ONLY "public"."Follower_User_Relation"
    ADD CONSTRAINT "Follower_User_Relation_userIsFollowed_fkey" FOREIGN KEY ("userIsFollowed") REFERENCES "public"."User"("userID");

ALTER TABLE ONLY "public"."Follower_User_Relation"
    ADD CONSTRAINT "Follower_User_Relation_userIsFollowing_fkey" FOREIGN KEY ("userIsFollowing") REFERENCES "public"."User"("userID");

ALTER TABLE ONLY "public"."Forum"
    ADD CONSTRAINT "Forum_creator_userID_fkey" FOREIGN KEY ("creator_userID") REFERENCES "public"."User"("userID");

ALTER TABLE ONLY "public"."Posts"
    ADD CONSTRAINT "Posts_associated_forumID_fkey" FOREIGN KEY ("associated_forumID") REFERENCES "public"."Forum"("forumID");

ALTER TABLE ONLY "public"."Posts"
    ADD CONSTRAINT "Posts_creator_userID_fkey" FOREIGN KEY ("creator_userID") REFERENCES "public"."User"("userID");

ALTER TABLE ONLY "public"."User_Like_Post_Relation"
    ADD CONSTRAINT "User_Like_Post_Relation_postID_fkey" FOREIGN KEY ("postID") REFERENCES "public"."Posts"("postID");

ALTER TABLE ONLY "public"."User_Like_Post_Relation"
    ADD CONSTRAINT "User_Like_Post_Relation_userID_fkey" FOREIGN KEY ("userID") REFERENCES "public"."User"("userID");

ALTER TABLE ONLY "public"."User"
    ADD CONSTRAINT "User_roleID_fkey" FOREIGN KEY ("roleID") REFERENCES "public"."Role"("roleID");

ALTER PUBLICATION "supabase_realtime" OWNER TO "postgres";

GRANT USAGE ON SCHEMA "public" TO "postgres";
GRANT USAGE ON SCHEMA "public" TO "anon";
GRANT USAGE ON SCHEMA "public" TO "authenticated";
GRANT USAGE ON SCHEMA "public" TO "service_role";

GRANT ALL ON TABLE "public"."Comment" TO "anon";
GRANT ALL ON TABLE "public"."Comment" TO "authenticated";
GRANT ALL ON TABLE "public"."Comment" TO "service_role";

GRANT ALL ON TABLE "public"."Follower_User_Relation" TO "anon";
GRANT ALL ON TABLE "public"."Follower_User_Relation" TO "authenticated";
GRANT ALL ON TABLE "public"."Follower_User_Relation" TO "service_role";

GRANT ALL ON TABLE "public"."Forum" TO "anon";
GRANT ALL ON TABLE "public"."Forum" TO "authenticated";
GRANT ALL ON TABLE "public"."Forum" TO "service_role";

GRANT ALL ON TABLE "public"."Posts" TO "anon";
GRANT ALL ON TABLE "public"."Posts" TO "authenticated";
GRANT ALL ON TABLE "public"."Posts" TO "service_role";

GRANT ALL ON TABLE "public"."Role" TO "anon";
GRANT ALL ON TABLE "public"."Role" TO "authenticated";
GRANT ALL ON TABLE "public"."Role" TO "service_role";

GRANT ALL ON TABLE "public"."User" TO "anon";
GRANT ALL ON TABLE "public"."User" TO "authenticated";
GRANT ALL ON TABLE "public"."User" TO "service_role";

GRANT ALL ON TABLE "public"."User_Like_Post_Relation" TO "anon";
GRANT ALL ON TABLE "public"."User_Like_Post_Relation" TO "authenticated";
GRANT ALL ON TABLE "public"."User_Like_Post_Relation" TO "service_role";

ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON SEQUENCES  TO "postgres";
ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON SEQUENCES  TO "anon";
ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON SEQUENCES  TO "authenticated";
ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON SEQUENCES  TO "service_role";

ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON FUNCTIONS  TO "postgres";
ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON FUNCTIONS  TO "anon";
ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON FUNCTIONS  TO "authenticated";
ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON FUNCTIONS  TO "service_role";

ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON TABLES  TO "postgres";
ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON TABLES  TO "anon";
ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON TABLES  TO "authenticated";
ALTER DEFAULT PRIVILEGES FOR ROLE "postgres" IN SCHEMA "public" GRANT ALL ON TABLES  TO "service_role";

RESET ALL;
