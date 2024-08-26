CREATE UNIQUE INDEX "Forum_forumTopic_key" ON public."Forum" USING btree ("forumTopic");

alter table "public"."Forum" add constraint "Forum_forumTopic_key" UNIQUE using index "Forum_forumTopic_key";


