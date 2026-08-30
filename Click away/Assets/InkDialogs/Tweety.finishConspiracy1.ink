INCLUDE AllVar.ink
VAR bad = ""
-> begin

=== begin
{ TweetyLike > 5: 
-> happy
- else: 
-> hate
}

=== happy
Welcome back! #anim:tweety_happy #char:Tweety #audio:bird
How was it? #anim:tweety_norm
+ [good] 
Great! #anim:tweety_happy 
-> who
+ [okay] 
Okay 

#anim:tweety_happy 
-> who
+ [bad] Fair, this isn't the most pleasant job
#anim:tweety_happy 
-> who
=== hate
You're done? #anim:tweety_norm #char:Tweety #audio:bird
Lets get this over with.
-> who

=== who
So, who do you consider as the "bad" of this conspiracy? #char:Tweety #audio:bird
+ [Soccer kid] 
~ bad = "'soccer kid'" 
->sure
+ [plane lover]
~ bad = "'plane lover'"
->sure
+ [gamer guy]
~ bad = "'gamer guy'"
->sure
=== sure
Are you sure its {bad}? #anim:tweety_norm
+[yes] -> next
+[no]-> who

=== next
Okay! Now you just gotta get them to submit to their punishment! #anim:tweety_happy #char:Tweety #audio:bird
+ [wha?] -> end
+ [yeah!] -> END

=== end
{ TweetyLike >= 6: 
It's the last step of your assigment. #anim:tweety_norm #char:Tweety #audio:bird
Don't worry! I'm sure you can do it!In case not, me and my Train will get you out of trouble! #anim:tweety_happy
->END
- else: 
You.. didn't read the guidelines.. #anim:tweety_norm #char:Tweety #audio:bird
You are killing two birds with one stone of stupidity here.
Simply "kill" the {bad}'s online personality so that the punishers can do their job without interuptions.
    + [kill!?]
    WHAT?! They are not THAT bad that they deserve death!  #anim:click_confused #char:Click #audio:main
    ~ TweetyLike++
    You are not actually killing them! #anim:tweety_shock #char:Tweety #audio:bird
    In fact, you are not really killing anyone!
    Just subdooing the online persona so it doesn't finght back during the actual punishment of the {bad}.
    ->END
    + [understood] -> END
}