# Coding Guidelines
## General Formatting Guidelines

- Preserve Settings: Follow the existing project formatting rules.
- Automatic Formatting: Regularly use Rider's automatic formatting function (Ctrl+Alt+L).

## Code Layout
- Line Length: Maximum of 120 characters per line.
- Indented Blocks: Use tabs or 4 spaces for indentation (depending on project settings).
- Blank Lines: Use blank lines to separate logical code blocks.

## Indentation and Spacing
- Indent Blocks: Always use 4 spaces per indentation level.
- Braces: Opening braces on the same line as the statement, closing braces on a new line.
- Operator Spacing: Add spaces around operators like +, -, *, /, =, ==, etc.
- Commas and Semicolons: Add a space after commas and semicolons, not before.

## Naming Conventions

- Classes and Methods: Use PascalCase.
- Variables and Fields: Use camelCase.
- Constants: Use SCREAMING_SNAKE_CASE.

## Comments
If not obvious, or the method is more than 5 lines, it should be commented.

- Single-line Comments: Use // for single-line comments
- Multi-line Comments: Use /* ... */ for multi-line comments.
- Documentation Comments: Use /// for documentation comments.

## Usings and Namespaces

- Sorting: Sort usings alphabetically and group by system namespace.
- Removing: Remove unused usings.
- Namespace: A file should contain a single namespace.

## Error Handling

- Exceptions: Always catch specific exceptions when possible.

## Unit Tests
Every method should be unit testable and have a unit test for it.

## Follow MVVM Pattern!