/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FirstAidKitService } from './firstAidKit.service';

describe('Service: FirstAidKit', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FirstAidKitService]
    });
  });

  it('should ...', inject([FirstAidKitService], (service: FirstAidKitService) => {
    expect(service).toBeTruthy();
  }));
});
