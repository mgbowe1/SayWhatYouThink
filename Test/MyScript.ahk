#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

^!s::Suspend

^j::
	value := RunWaitOne("node " . A_ScriptDir . "\test.js")
	
	RunWaitOne(command) {
    shell := ComObjCreate("WScript.Shell")
    ; Execute a single command via cmd.exe
    exec := shell.Exec(command)
    ; Read and return the command's output
    return exec.StdOut.ReadAll()
	}
	
	Send, %value%
	