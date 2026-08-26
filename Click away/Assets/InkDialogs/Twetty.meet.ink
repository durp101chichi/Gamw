VAR name = "Conductor"
INCLUDE AllVar.ink
-> Begin
=== Begin
ALL ABOARD!! #anim:tweety_happy #char:{name} #audio:bird
TRAIN IS LEAVING IN 5 MINUTES!!!
+ [hi]-> ticket
+ [train?] -> train

=== train
YES YES!! A TRAIN TO ANYWHERE IN THE WEB!
my life, my beauty, my job #anim:tweety_norm #char:{name} #audio:bird
my beautiful train~
JUST A TICKET IS ALL YOU NEEEEEEEEEEEED!!!#anim:tweety_happy #char:{name}
~TweetyLike++
-> ticket
=== ticket
Oh! #anim:tweety_shock #char:{name} #audio:bird
Hello! #anim:tweety_norm #char:{name}
Can I please have your ticket?
+ [*give ticket*] 
~TweetyLike++
-> onTrain 
+ [why?] -> who
+ [no]-> no

=== who
~name = "Tweety"
Well, I am Tweety, the guy to get you anywhere! #anim:tweety_happy #char:{name} #audio:bird
And I don't want to be "Tweety, the guy that brought a virus into your computer system".. #anim:tweety_shock #char:{name}
So, you got a ticket? #anim:tweety_norm #char:{name}
+ [yes] -> onTrain
+ [no] -> no
=== no
~TweetyLike--
uh? #anim:tweety_norm #char:{name} #audio:bird
THEN WHY ARE YOU STANDING AROUND HERE! #anim:tweety_shock #char:{name}
I HAVE A JOB TO DO!
+ [jk] -> onTrain
+ [you sure?] -> uSure
=== uSure
~TweetyLike--
Job for who? #anim:click_confused #char:Click #audio:main
It's empty out here..
..#anim:tweety_shock #char:{name} #audio:bird
I AM WAITING FOR SOMEONE REALLY IMPORTANT!!
So, yes, I HAVE a job to do..#anim:tweety_norm #char:{name}
And so do they...
+ [*give ticket*] -> onTrain 

=== onTrain
Oooooooh.. you are the new guy! #anim:tweety_norm #char:{name} #audio:bird
~name = "Tweety"
Well, I am your traveling advisor Tweety. #anim:tweety_norm #char:{name}
{ TweetyLike < 5:
Don't EVER talk to me like that again. #anim:tweety_norm #char:{name}
- else:
Nice to meet you! #anim:tweety_happy #char:{name}
I'm sure you have met Forcast allready! Sorry if he didn't act too "profecionally" #anim:tweety_norm #char:{name}
He is like that all the time..
Lets get you to your destination, best of luck!#anim:tweety_happy #char:{name}
}
->END