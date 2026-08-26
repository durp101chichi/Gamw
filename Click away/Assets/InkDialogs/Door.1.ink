INCLUDE AllVar.ink
-> Begin
=== Begin
Hi? #anim:click_confused #char:Click #audio:main

Password #anim:door_look #char:Eye in the Wall #audio:door
+ [huh?]-> Help
+ [sure] -> Tab

=== Help
~DoorLike--
Don't play dumb #anim:door_anoyed #audio:door
->Tab

=== Tab
#anim:help
#char:help
#audio:door
"press TAB to open inventory
#anim:door_look
#char:Eye in the Wall
Um.. hello? You still there?
+ [ClickAway] ->END
+ [no] -> no
+ [what?] -> Help

=== no
~DoorLike--
#char:Eye in the Wall
#anim:door_anoyed
#audio:door
I hate you
+ [ClickAway] -> JK
+ [what?] -> Help

=== JK
#char:Click #audio:main
#anim:click_hah
nuh-uh, ClickAway
    -> END
