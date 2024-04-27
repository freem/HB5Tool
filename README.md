# HB5Tool

This is a tool for viewing (and eventually, editing) various files from Hardball 5.

The primary target is the DOS version, though the PlayStation 1 version is semi-supported.
Some files from HardBall 4 are also supported, unintentionally.

The current version is a very rough proof-of-concept, and doesn't allow for any
editing. Documentation is non-existent. All of these issues (and more) will
eventually be fixed.

## Supported Formats
Kind of. It gets a bit tricky. All of these are in varying states of completion.

- Player Exports (`*.btr`, `*.pit`)
- Team Exports (`*.hb5`)
- League Data (`*.lgd`)
- "Binary files", which covers more ground than expected. Support is limited.
 - "Glue" archives (files that have "MB" as the first two bytes) are supported. This includes the PS1 `*.glu` format.
 - `CUSTOM.BIN` and `CUSTOM_D.BIN`
 - `DEFAULTS.BIN` and `DEF_D.BIN`
 - and some files extracted from the main archive(s).

## Legal Notes

I'm not affiliated with Accolade, MindSpan, the MLBPA, the MLB, or whoever currently owns the HardBall license.

This tool is provided for informational and educational purposes.
