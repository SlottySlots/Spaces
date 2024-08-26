set check_function_bodies = off;

CREATE OR REPLACE FUNCTION public.get_top_forums()
 RETURNS TABLE(forumid uuid, forumtopic character varying, post_count bigint)
 LANGUAGE plpgsql
AS $function$
BEGIN
  RETURN QUERY
  SELECT 
    f."forumID", 
    f."forumTopic", 
    COUNT(p."postID") AS post_count
  FROM 
    public."Forum" f
  LEFT JOIN 
    public."Posts" p 
  ON 
    f."forumID" = p."associated_forumID"
  GROUP BY 
    f."forumID", f."forumTopic"
  ORDER BY 
    post_count DESC
  LIMIT 3;
END;
$function$
;


