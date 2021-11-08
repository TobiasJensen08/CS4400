My email is "kripto289@gmail.com"
You can contact me for any questions.
My English is not very good, and if there are any translation errors, you can let me know :)


Pack includes prefabs of main effects + prefabs of collision effects (\Assets\KriptoFX\Explosions\Prefabs).
Support platforms: all platforms (PC/Consoles/VR/Mobiles/URP/HDRP)
All effects tested on Oculus Rift CV1 with single and dual mode rendering and works correctly.


------------------------------------------------------------------------------------------------------------------------------------------
IMPORTANT settings for DEFAULT built-in rendering:

Before update please remove old version of the package (to avoiding useless editor scripts)

1) You need activate HDR rendering. Edit -> ProjectSettings -> Graphics -> select current build target -> uncheck "use default" for tier1, tier2, tier3 -> set "Use HDR = true"
2) Enable HDR rendering in the current camera. MainCamera -> "AllowHDR = true"
If you have forward rendering path (by default in Unity), you need disable antialiasing "edit->project settings->quality->antialiasing"
or turn of "MSAA" on main camera, because HDR does not works with msaa. If you want to use HDR and MSAA then use "post effect msaa".

3) Add postprocessing stack package to project. Window -> Package Manager -> PostProcessing -> Instal
4) MainCamera -> AddComponent -> "Post Processing Layer". For "Layer" you should set custom layer (for example UI, or Postprocessing)
5) Create empty Gameobject and set custom layer as in the camera processing layer (for example UI). Gameobject -> AddComponent -> "Post Process Volume".
Add included postprocessing profile to "Post Process Volume" "\Assets\KriptoFX\Explosions\PostProcess Profile.asset"

------------------------------------------------------------------------------------------------------------------------------------------
IMPORTANT settings for HDRP:

Before update please remove old version of the package (to avoiding useless editor scripts)

1) Import HDRP patch "\Assets\KriptoFX\Explosions\HDRP and URP patches"
2) Add "Bloom" and "tonemapping ACES" posteffects.
Camera -> Add Component -> Volume -> "IsGlobal = true" -> set the profile "\Assets\KriptoFX\Realistic Effects Pack v1\PostProcess Profile.asset"


important posteffect settings:
1) Bloom with follow settings
	Threshold 1.5
	Intencity 0.2-0.5
	Scatter 0.9
2) Tonemapping -> "ACES"



------------------------------------------------------------------------------------------------------------------------------------------
IMPORTANT settings for URP:

Before update please remove old version of the package (to avoiding useless editor scripts)

1) Import URP patch "\Assets\KriptoFX\Explosions\HDRP and URP patches"
2) For main camera you need set "Depth texture = ON", "Opaque texture = ON" and "Post Effect = ON"
3) You need activate HDR rendering. Edit -> ProjectSettings -> Graphics -> select current scriptable render pipeline settings file -> Quality -> set "HDR = true"
4) MainCamera -> AddComponent -> Volume -> "IsGlobal = true" .
5) Volume -> Profile -> \Assets\KriptoFX\Explosions\PostProcess Profile.asset

important posteffect settings:
1) Bloom with follow settings
	Threshold 1
	Intencity 2
	Scatter 0.9
2) Tonemapping -> "ACES"
3) MainCamera -> "PostEffects=true"

------------------------------------------------------------------------------------------------------------------------------------------
Using effects:

Just drag and drop prefab of effect on scene and use that (for example, bufs or projectiles).

