using UnityEngine;

public class Footsteps_AnimationEvent : MonoBehaviour {
  [SerializeField] AudioSource Footstep;
  AudioClip _footstep_Clip;
  Animator _animator;
  float _firstPitch;
  float _rangeChangePitch = 0.2f;

  void Awake() {
    _footstep_Clip = this.gameObject.GetComponent<AudioClip>();
    _animator = this.gameObject.GetComponent<Animator>();

    _firstPitch = Footstep.pitch;
  }

  //‘«‰¹
  void Play_footsteps() {
    if (_animator.GetFloat("Speed") >= 0.05) {
      Footstep.pitch = _firstPitch + Random.Range(0f, _rangeChangePitch);
      Footstep.Play();
    }
  }

  //ƒWƒƒƒ“ƒv‚µ‚½‚Æ‚«‚Ì‘«‰¹
  void Play_footstep_Jump() {
    Footstep.pitch = _firstPitch + Random.Range(0f, _rangeChangePitch);
    Footstep.Play();
  }
}
