import { Component } from '@angular/core';
import { Affirmation, IAffirmation } from '../../_model/affirmation';
import { User } from '../../_model/user';
import { AffirmationService } from '../../_services/affirmation.service';

@Component({
  selector: 'app-affirmation',
  templateUrl: './affirmation.component.html',
  styleUrls: ['./affirmation.component.css']
})
export class AffirmationComponent {
  user: User;
  affirmation: IAffirmation;
  userAffirmations: Affirmation[] = [];

  constructor(private affirmationService: AffirmationService) { }

  getAffirmation(id: number) {
    this.affirmationService.getAffirmation(id).subscribe(result => {
      this.affirmation = result;
    });
  }

  getAffirmationsForUser(userId: number) {
    this.affirmationService.getAffirmationsForUser(userId).subscribe(result => {
      this.userAffirmations = result;
      console.log(result);
    })
  }

  createAffirmation() {
    var aff = new Affirmation();
    aff.userId = 4;
    aff.affirmationText = 'This is a new Affirmation';
    this.affirmationService.createAffirmation(aff);
  }

  removeAffirmation(id: number) {
    this.affirmationService.removeAffirmation(id);
  }
}
