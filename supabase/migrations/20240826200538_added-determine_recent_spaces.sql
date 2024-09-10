set check_function_bodies = off;

CREATE OR REPLACE FUNCTION public.determine_recent_spaces()
 RETURNS TABLE(forumid uuid, forumtopic character varying, post_count bigint)
 LANGUAGE plpgsql
AS $function$
BEGIN
    RETURN QUERY
    SELECT 
        tf."forumID",
        tf."forumTopic",
        COUNT(p."postID") AS post_count
    FROM 
        public."Forum" tf
    LEFT JOIN 
        public."Posts" p ON p."associated_forumID" = tf."forumID"
    GROUP BY 
        tf."forumID", tf."forumTopic"
    ORDER BY 
        tf."created_at" DESC
    LIMIT 3;
END;
$function$
;


