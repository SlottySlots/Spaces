alter table "public"."Forum" add column "postCount" bigint default '0'::bigint;

set check_function_bodies = off;

CREATE OR REPLACE FUNCTION public.update_post_count()
 RETURNS trigger
 LANGUAGE plpgsql
AS $function$
BEGIN
  -- Increment post count on insert
  IF TG_OP = 'INSERT' THEN
    UPDATE public."Forum"
    SET "postCount" = "postCount" + 1
    WHERE "forumID" = NEW."associated_forumID";
    
  -- Decrement post count on delete
  ELSIF TG_OP = 'DELETE' THEN
    UPDATE public."Forum"
    SET "postCount" = "postCount" - 1
    WHERE "forumID" = OLD."associated_forumID";
  END IF;
  
  RETURN NEW;
END;
$function$
;

CREATE TRIGGER trigger_update_post_count
AFTER INSERT OR DELETE ON public."Posts"
FOR EACH ROW
EXECUTE FUNCTION update_post_count();


drop policy "Enable update for users based on userID" on "public"."Forum";

create policy "Enable update for users based on userID"
on "public"."Forum"
as permissive
for update
to authenticated
using (true)
with check (true);



