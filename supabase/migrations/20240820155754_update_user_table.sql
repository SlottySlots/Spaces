alter table "public"."User" alter column "email" set not null;

alter table "public"."User" alter column "profilePic" set data type character varying using "profilePic"::character varying;

CREATE UNIQUE INDEX "User_email_key" ON public."User" USING btree (email);

CREATE UNIQUE INDEX "User_userName_key" ON public."User" USING btree ("userName");

alter table "public"."User" add constraint "User_email_key" UNIQUE using index "User_email_key";

alter table "public"."User" add constraint "User_userName_key" UNIQUE using index "User_userName_key";


