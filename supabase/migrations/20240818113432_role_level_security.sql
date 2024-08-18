alter table "public"."Comment" enable row level security;

alter table "public"."Follower_User_Relation" enable row level security;

alter table "public"."Forum" enable row level security;

alter table "public"."Posts" enable row level security;

alter table "public"."Role" enable row level security;

alter table "public"."User" enable row level security;

alter table "public"."User_Like_Post_Relation" enable row level security;

create policy "Enable delete for users based on userID"
on "public"."Comment"
as permissive
for delete
to authenticated
using ((( SELECT auth.uid() AS uid) = "creator_UserID"));


create policy "Enable insert for authenticated users only"
on "public"."Comment"
as permissive
for insert
to authenticated
with check (true);


create policy "Enable read access for all users"
on "public"."Comment"
as permissive
for select
to public
using (true);


create policy "Enable update for users based on userID"
on "public"."Comment"
as permissive
for update
to authenticated
using ((( SELECT auth.uid() AS uid) = "creator_UserID"))
with check ((( SELECT auth.uid() AS uid) = "creator_UserID"));


create policy "Enable delete for users based on userID"
on "public"."Follower_User_Relation"
as permissive
for delete
to authenticated
using ((( SELECT auth.uid() AS uid) = "userIsFollowing"));


create policy "Enable insert for authenticated users only"
on "public"."Follower_User_Relation"
as permissive
for insert
to authenticated
with check (true);


create policy "Enable read access for all users"
on "public"."Follower_User_Relation"
as permissive
for select
to public
using (true);


create policy "Enable update for users based on userID"
on "public"."Follower_User_Relation"
as permissive
for update
to authenticated
using ((( SELECT auth.uid() AS uid) = "userIsFollowing"))
with check ((( SELECT auth.uid() AS uid) = "userIsFollowing"));


create policy "Enable delete for users based on userID"
on "public"."Forum"
as permissive
for delete
to authenticated
using ((( SELECT auth.uid() AS uid) = "creator_userID"));


create policy "Enable insert for authenticated users only"
on "public"."Forum"
as permissive
for insert
to authenticated
with check (true);


create policy "Enable read access for all users"
on "public"."Forum"
as permissive
for select
to public
using (true);


create policy "Enable update for users based on userID"
on "public"."Forum"
as permissive
for update
to authenticated
using ((( SELECT auth.uid() AS uid) = "creator_userID"))
with check ((( SELECT auth.uid() AS uid) = "creator_userID"));


create policy "Enable delete for users based on userID"
on "public"."Posts"
as permissive
for delete
to authenticated
using ((( SELECT auth.uid() AS uid) = "creator_userID"));


create policy "Enable insert for authenticated users only"
on "public"."Posts"
as permissive
for insert
to authenticated
with check (true);


create policy "Enable read access for all users"
on "public"."Posts"
as permissive
for select
to public
using (true);


create policy "Enable update for users based on userID"
on "public"."Posts"
as permissive
for update
to authenticated
using ((( SELECT auth.uid() AS uid) = "creator_userID"))
with check ((( SELECT auth.uid() AS uid) = "creator_userID"));


create policy "Enable insert for authenticated users only"
on "public"."Role"
as permissive
for insert
to authenticated
with check (true);


create policy "Enable read access for all users"
on "public"."Role"
as permissive
for select
to public
using (true);


create policy "Enable delete for users based on userID"
on "public"."User"
as permissive
for delete
to authenticated
using ((( SELECT auth.uid() AS uid) = "userID"));


create policy "Enable insert for authenticated users only"
on "public"."User"
as permissive
for insert
to authenticated
with check (true);


create policy "Enable read access for all users"
on "public"."User"
as permissive
for select
to public
using (true);


create policy "Enable update for users based on userID"
on "public"."User"
as permissive
for update
to public
using ((( SELECT auth.uid() AS uid) = "userID"))
with check ((( SELECT auth.uid() AS uid) = "userID"));


create policy "Enable delete for users based on userID"
on "public"."User_Like_Post_Relation"
as permissive
for delete
to public
using ((( SELECT auth.uid() AS uid) = "userID"));


create policy "Enable insert for authenticated users only"
on "public"."User_Like_Post_Relation"
as permissive
for insert
to authenticated
with check (true);


create policy "Enable read access for all users"
on "public"."User_Like_Post_Relation"
as permissive
for select
to public
using (true);


create policy "Enable update for users based on userID"
on "public"."User_Like_Post_Relation"
as permissive
for update
to authenticated
using ((( SELECT auth.uid() AS uid) = "userID"))
with check ((( SELECT auth.uid() AS uid) = "userID"));



