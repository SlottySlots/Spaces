set check_function_bodies = off;

CREATE OR REPLACE FUNCTION public.get_post_count_by_user(user_id uuid)
 RETURNS integer
 LANGUAGE plpgsql
AS $function$BEGIN
    RETURN (
        SELECT COUNT(DISTINCT "associated_forumID")
        FROM "Posts"
        WHERE "creator_userID" = user_id
    );
END;$function$
;


