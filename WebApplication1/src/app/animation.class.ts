declare function animPage(): void;
declare function initMap(): void;
declare function initCounter(): void;
declare function customForm(): void;

export class AnimationClass {
  public static animWeb() {
  animPage();
}
public static animWebMap() {
    initMap();
    initCounter();
}
public static animBar() {
    customForm();
}
}
