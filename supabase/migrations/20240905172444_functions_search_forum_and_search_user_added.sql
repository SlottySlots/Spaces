set check_function_bodies = off;

CREATE OR REPLACE FUNCTION public.search_forum(search_term text)
 RETURNS TABLE(forumid uuid, creator_userid uuid, forumtopic character varying)
 LANGUAGE plpgsql
AS $function$
BEGIN
    RETURN QUERY
    SELECT
        "forumID",
        "creator_userID",
        "forumTopic"
    FROM public."Forum"
    WHERE to_tsvector('german', replace(regexp_replace("forumTopic", '[^a-zA-Z0-9 ]', '', 'g'), ' ', '')) @@ to_tsquery('german', replace(regexp_replace(search_term, '[^a-zA-Z0-9 ]', '', 'g'), ' ', ''))
       OR replace(regexp_replace("forumTopic", '[^a-zA-Z0-9 ]', '', 'g'), ' ', '') ILIKE '%' || replace(regexp_replace(search_term, '[^a-zA-Z0-9 ]', '', 'g'), ' ', '') || '%'
       LIMIT 10;
END;
$function$
;

CREATE OR REPLACE FUNCTION public.search_user(search_term text)
 RETURNS TABLE(userid uuid, username character varying)
 LANGUAGE plpgsql
AS $function$
BEGIN
    RETURN QUERY
    SELECT
        "userID",
        "userName"
    FROM public."User"
    WHERE to_tsvector('german', replace(regexp_replace("userName", '[^a-zA-Z0-9 ]', '', 'g'), ' ', '')) @@ to_tsquery('german', replace(regexp_replace(search_term, '[^a-zA-Z0-9 ]', '', 'g'), ' ', ''))
       OR replace(regexp_replace("userName", '[^a-zA-Z0-9 ]', '', 'g'), ' ', '') ILIKE '%' || replace(regexp_replace(search_term, '[^a-zA-Z0-9 ]', '', 'g'), ' ', '') || '%'
       LIMIT 10;
END;
$function$
;


