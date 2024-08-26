# Änderungen an der Datenbank

Es gibt zwei grundlegende Wege, um Änderungen an unseren lokalen Datenbanken und an der Online-Supabase-Datenbank vorzunehmen.

## 1. Klassischer Weg mit SQL-Skripten

Die erste Möglichkeit ist der klassische Ansatz: Man erstellt manuell ein SQL-Skript mit den gewünschten Änderungen und legt dieses im Ordner `supabase/migrations` ab. So wird es allen Teammitgliedern zugänglich gemacht. Um die Änderungen dann in die Datenbank zu übernehmen, muss jeder das neue Skript auf der Supabase-Webseite unter [http://localhost:54323/project/default/sql/1](http://localhost:54323/project/default/sql/1) einfügen und ausführen.

## 2. Supabase CLI verwenden

Die zweite, etwas modernere und bequemere Methode ist die Nutzung der Supabase CLI. Um diese zu installieren, folge einfach den Anweisungen im [Supabase CLI Guide](https://supabase.com/docs/guides/cli/getting-started?queryGroups=platform&platform=windows).

### Supabase Umgebung starten

Sobald die CLI eingerichtet ist, navigiere in den `SlottyMedia`-Ordner (nicht in den des C#-Projekts), öffne die Konsole und führe den folgenden Befehl aus:


 ```bash
 supabase start
 ```

Damit wird automatisch eine Supabase-Umgebung mithilfe von Docker erstellt, ohne dass du manuell eingreifen musst.

### Aktuelle Migration anwenden

Um die aktuelle Migration in die Datenbank zu laden, führe diesen Befehl aus:


 ```bash
 supabase migration up
 ```

### Änderungen an alle weitergeben

Um deine Änderungen mit dem Team zu teilen, benutze folgenden Befehl:


 ```bash
 supabase db diff -f <name-of-file>
 ```

### Datenbank zurücksetzen

Damit andere die Änderungen übernehmen können, müssen sie lediglich den folgenden Befehl ausführen:

 ```bash
 supabase db reset
 ```

Mit diesen Schritten wird sichergestellt, dass alle stets mit der aktuellsten Datenbankversion arbeiten.
