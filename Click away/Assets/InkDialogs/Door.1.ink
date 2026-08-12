
-> Begin
=== Begin
Hi? #anim:click_confused #char:Click

Password #anim:door_look #char:Eye in the Wall
+ [huh?]-> Help
+ [sure] -> Tab

=== Help

Don't play dumb #anim:door_anoyed
->Tab

=== Tab
#anim:help
#char:help
"press TAB to open inventory
#anim:door_look
#char:Eye in the Wall
Um.. hello? You still there?
+ [ClickAway] ->END
+ [no] -> no
+ [what?] -> Help

=== no
#char:Eye in the Wall
#anim:door_anoyed
I hate you
+ [ClickAway] -> JK
+ [what?] -> Help

=== JK
#char:Click
#anim:click_hah
nuh-uh, ClickAway
    -> END
