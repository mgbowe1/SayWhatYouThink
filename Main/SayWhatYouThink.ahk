#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

DllCall("AllocConsole")
WinHide % "ahk_id " DllCall("GetConsoleWindow", "ptr")

; Toggle hot key trigger
^!s::Suspend

; Hot Key for simple speach to text
^!n::
	SplashImage, mic.png, B Y0
	comment := RunWaitOne("QuickDocConsole.exe " . "N")	; Store comments from user using speech to text program
	SplashImage, Off
	Send, %comment%	; Send comment text to editor
	Return

; Hot Key for C style comments
^!c::
	SplashImage, mic.png, B Y0
	comment := RunWaitOne("QuickDocConsole.exe " . "C")	; Store comments from user using speech to text program
	SplashImage, Off
	Send, %comment%	; Send comment text to editor
	Return

; Hot Key for Python
^!p::
	SplashImage, mic.png, B Y0
	comment := RunWaitOne("QuickDocConsole.exe " . "P")	; Store comments from user using speech to text program
	SplashImage, Off
	Send, %comment%	; Send comment text to editor
	Return
	
; Hot Key for LISP style comments
^!l::
	SplashImage, mic.png, B Y0
	comment := RunWaitOne("QuickDocConsole.exe " . "L")	; Store comments from user using speech to text program
	SplashImage, Off
	Send, %comment%	; Send comment text to editor
	Return
	
RunWaitOne(command) {
    shell := ComObjCreate("WScript.Shell")	; Execute speech to text program
    exec := shell.Exec(command)
    return exec.StdOut.ReadAll()	; Read and return the comment text
}